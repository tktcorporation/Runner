package repositories

import (
	"context"
	"log"

	"cloud.google.com/go/firestore"
	firebase "firebase.google.com/go"
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
	return dispatchFirestore(ctx, projectID, add)
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

func dispatchFirestore(ctx context.Context, projectID string, fu func(ctx context.Context, client firestore.Client) *firestore.WriteResult) *firestore.WriteResult {
	conf := &firebase.Config{ProjectID: projectID}
	app, err := firebase.NewApp(ctx, conf)
	if err != nil {
		log.Fatalln(err)
	}
	client, err := app.Firestore(ctx)
	if err != nil {
		log.Fatalln(err)
	}
	defer client.Close()
	return fu(ctx, *client)
}
