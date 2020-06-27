package repository

import (
	"context"
	"encoding/json"
	"log"
	"strconv"

	"cloud.google.com/go/firestore"
	"github.com/tktcorporation/Runner/domain/score"
	"github.com/tktcorporation/Runner/repository/collection"
)

// ScoresRepository for scores
type ScoresRepository struct {
	base Repository
}

func BuildScores(ctx context.Context, projectID string, isDev bool) ScoresRepository {
	repo := Build(ctx, projectID, isDev, getCollectionName(isDev))
	return ScoresRepository{repo}
}

// Close firestore client
func getCollectionName(isDev bool) string {
	if !isDev {
		return collection.ScoresPrd.String()
	}
	return collection.ScoresDev.String()
}

// Add is a func for adding
func (repo *ScoresRepository) Add(score score.Score) *firestore.WriteResult {
	var _, result, err = repo.base.client.Collection(repo.base.collection).Add(repo.base.ctx, score)
	if err != nil {
		log.Fatalf("Failed adding doc to firestore: %v", err)
	}
	return result
}

// Read fetch all scores data
func (repo *ScoresRepository) Read() (result []score.Score) {
	iter := repo.base.client.Collection(repo.base.collection).OrderBy("total_point", firestore.Desc).Limit(10).Documents(repo.base.ctx)
	docs, err := iter.GetAll()
	if err != nil {
		log.Fatalf("Failed to Get Documents: %v", err)
	}

	for _, v := range docs {
		score, err := mapToStruct(v.Data())
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
func mapToStruct(m map[string]interface{}) (score.Score, error) {
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
