package repositories

import (
	"context"
	"encoding/json"
	"log"
	"strconv"

	"cloud.google.com/go/firestore"
	firestoreconf "github.com/tktcorporation/Runner/firestore"
	score "github.com/tktcorporation/Runner/score"
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
type UsersRepository struct {
	Context   context.Context
	ProjectID string
}

// Add is a func for adding
func (arg *UsersRepository) Add(score score.Score) *firestore.WriteResult {
	return dispatchFirestoreAddResult(arg.Context, arg.ProjectID, score, add)
}

// Rdd is a func for reading
func (arg *UsersRepository) Read() []score.Score {
	return dispatchFirestoreReadResult(arg.Context, arg.ProjectID, read)
}

func add(ctx context.Context, client firestore.Client, score score.Score) *firestore.WriteResult {
	var _, result, err = client.Collection("scores").Add(ctx, score)
	if err != nil {
		log.Fatalf("Failed adding alovelace: %v", err)
	}
	return result
}

func read(ctx context.Context, client *firestore.Client) (result []score.Score) {

	iter := client.Collection("scores").Documents(ctx)
	docs, err := iter.GetAll()
	if err != nil {
		log.Fatalf("Failed to Get Documents: %v", err)
	}

	for _, v := range docs {
		score, err := MapToStruct(v.Data())
		if err != nil {
			log.Fatalf("UnquoteError: %#v", err)
		}
		// log.Printf("data: %#v", v.Data())
		// log.Printf("scoreStruct: %#v", scoreStruct)
		result = append(result, score)
	}
	return result
}

// MapToStruct convert map to struct
func MapToStruct(m map[string]interface{}) (score.Score, error) {
	var sco score.Score
	tmp, err := json.Marshal(m)
	if err != nil {
		return sco, err
	}
	log.Printf("Marshaledjson: %#v", string(tmp))
	s, err := strconv.Unquote("`" + string(tmp) + "`")
	log.Printf("Unquote: %s", s)
	if err != nil {
		return sco, err
	}
	err = json.Unmarshal([]byte(s), &sco)
	log.Printf("UnMarshaledjson: %#v", sco)
	if err != nil {
		return sco, err
	}
	return sco, nil
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
	fu func(ctx context.Context, client *firestore.Client) []score.Score,
) []score.Score {
	client := firestoreconf.GetClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, client)
}
