package repositories

import (
	"context"
	"encoding/json"
	"log"
	"strconv"

	"cloud.google.com/go/firestore"
	firestoreconf "github.com/tktcorporation/Runner/firestore"
	"github.com/tktcorporation/Runner/score"
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
func (arg *UsersRepository) Add(score score.Score, isDev bool) *firestore.WriteResult {
	return dispatchFirestoreAddResult(arg.Context, arg.ProjectID, score, isDev, add)
}

// Read fetch all scores data
func (arg *UsersRepository) Read(isDev bool) []score.Score {
	return dispatchFirestoreReadResult(arg.Context, arg.ProjectID, isDev, read)
}

func add(ctx context.Context, client firestore.Client, score score.Score, isDev bool) *firestore.WriteResult {
	collection := scoreDev.String()
	if !isDev {
		collection = scorePrd.String()
	}
	var _, result, err = client.Collection(collection).Add(ctx, score)
	if err != nil {
		log.Fatalf("Failed adding doc to firestore: %v", err)
	}
	return result
}

type collection int

const (
	scorePrd collection = iota
	scoreDev
)

func (c collection) String() string {
	switch c {
	case scorePrd:
		return "scores"
	case scoreDev:
		return "scores_dev"
	default:
		return "unknown"
	}
}

func read(ctx context.Context, client *firestore.Client, isDev bool) (result []score.Score) {
	collection := scoreDev.String()
	if !isDev {
		collection = scorePrd.String()
	}
	iter := client.Collection(collection).OrderBy("total_point", firestore.Desc).Limit(10).Documents(ctx)
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
	s, err := strconv.Unquote("`" + string(tmp) + "`")
	if err != nil {
		return sco, err
	}
	err = json.Unmarshal([]byte(s), &sco)
	if err != nil {
		return sco, err
	}
	return sco, nil
}

func dispatchFirestoreAddResult(
	ctx context.Context, projectID string,
	score score.Score, isDev bool,
	fu func(ctx context.Context, client firestore.Client, score score.Score, isDev bool) *firestore.WriteResult,
) *firestore.WriteResult {
	client := firestoreconf.GetClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, *client, score, isDev)
}
func dispatchFirestoreReadResult(
	ctx context.Context, projectID string, isDev bool,
	fu func(ctx context.Context, client *firestore.Client, isDev bool) []score.Score,
) []score.Score {
	client := firestoreconf.GetClient(ctx, projectID)
	defer client.Close()
	return fu(ctx, client, isDev)
}
