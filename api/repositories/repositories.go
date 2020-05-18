package repositories

import (
	"context"
	"fmt"
	"log"

	"cloud.google.com/go/firestore"
	firestoreconf "github.com/tktcorporation/Runner/firestore"
	score "github.com/tktcorporation/Runner/score"
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
func (arg *UsersRepository) Add(ctx context.Context, projectID string, score score.Score) *firestore.WriteResult {
	return dispatchFirestoreAddResult(ctx, projectID, score, add)
}

// Rdd is a func for reading
func (arg *UsersRepository) Read(ctx context.Context, projectID string) ([]*firestore.DocumentSnapshot, error) {
	return dispatchFirestoreReadResult(ctx, projectID, read)
}

func add(ctx context.Context, client firestore.Client, score score.Score) *firestore.WriteResult {
	var _, result, err = client.Collection("scores").Add(ctx, score)
	if err != nil {
		log.Fatalf("Failed adding alovelace: %v", err)
	}
	return result
}

func read(ctx context.Context, client *firestore.Client) ([]*firestore.DocumentSnapshot, error) {
	iter := client.Collection("scores").Documents(ctx)
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
	score score.Score,
	fu func(ctx context.Context, client firestore.Client, score score.Score) *firestore.WriteResult,
) *firestore.WriteResult {
	client := firestoreconf.GetClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, *client, score)
}
func dispatchFirestoreReadResult(
	ctx context.Context, projectID string,
	fu func(ctx context.Context, client *firestore.Client) ([]*firestore.DocumentSnapshot, error),
) ([]*firestore.DocumentSnapshot, error) {
	client := firestoreconf.GetClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, client)
}
