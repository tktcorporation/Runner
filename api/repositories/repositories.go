package repositories

import (
	"context"
	"fmt"
	"log"

	"cloud.google.com/go/firestore"
	firebase "firebase.google.com/go"
	"google.golang.org/api/iterator"
)

// Repository is for using firestore
type Repository interface {
	Add(ctx context.Context, projectID string)
}

// Add is a func for adding
// func Add(ctx context.Context, arg Repository, projectID string) {
// 	arg.add(ctx, projectID)
// }

// UsersRepository is for using firestore users
type UsersRepository struct{}

// Add is a func for adding
func (arg *UsersRepository) Add(ctx context.Context, projectID string) *firestore.WriteResult {
	return dispatchFirestoreAddResult(ctx, projectID, add)
}

// Rdd is a func for reading
func (arg *UsersRepository) Read(ctx context.Context, projectID string) ([]*firestore.DocumentSnapshot, error) {
	return dispatchFirestoreReadResult(ctx, projectID, read)
}

func add(ctx context.Context, client firestore.Client) *firestore.WriteResult {
	var _, result, err = client.Collection("users").Add(ctx, map[string]interface{}{
		"first": "Ada",
		"last":  "Lovelace",
		"born":  1815,
	})
	if err != nil {
		log.Fatalf("Failed adding alovelace: %v", err)
	}
	return result
}

func read(ctx context.Context, client *firestore.Client) ([]*firestore.DocumentSnapshot, error) {
	iter := client.Collection("users").Documents(ctx)
	// result := make(map[string]interface{})
	for {
		doc, err := iter.Next()
		if err == iterator.Done {
			break
		}
		if err != nil {
			log.Fatalf("Failed to iterate: %v", err)
		}
		fmt.Println(doc.Data())
	}
	return iter.GetAll()
}

func dispatchFirestoreAddResult(
	ctx context.Context, projectID string,
	fu func(ctx context.Context, client firestore.Client) *firestore.WriteResult,
) *firestore.WriteResult {
	client := getFirestoreClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, *client)
}
func dispatchFirestoreReadResult(
	ctx context.Context, projectID string,
	fu func(ctx context.Context, client *firestore.Client) ([]*firestore.DocumentSnapshot, error),
) ([]*firestore.DocumentSnapshot, error) {
	client := getFirestoreClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, client)
}

var getFirestoreClient = func(ctx context.Context, projectID string) *firestore.Client {
	conf := &firebase.Config{ProjectID: projectID}
	app, err := firebase.NewApp(ctx, conf)
	if err != nil {
		log.Fatalln(err)
	}
	client, err := app.Firestore(ctx)
	if err != nil {
		log.Fatalln(err)
	}
	return client
}
