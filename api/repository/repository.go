package repository

import (
	"context"

	"cloud.google.com/go/firestore"
	firestoreconf "github.com/tktcorporation/Runner/infrastructure/firestore"
)

// Repository is for using firestore
type Repository struct {
	ctx        context.Context
	projectID  string
	collection string
	client     *firestore.Client
}

// Closeable methods
type Closeable interface {
	Close()
}

// Build repository for using firestore
func Build(ctx context.Context, projectID string, isDev bool, collection string) Repository {
	client := firestoreconf.GetClient(ctx, projectID)
	return Repository{
		ctx,
		projectID,
		collection,
		client,
	}
}

// Close firestore client
func (repo Repository) Close() {
	repo.client.Close()
}
