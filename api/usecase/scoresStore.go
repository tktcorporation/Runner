package usecase

import (
	"cloud.google.com/go/firestore"
	"github.com/tktcorporation/Runner/domain/score"
)

// ScoresRepository for scores
type ScoresRepository interface {
	Add(score score.Score) *firestore.WriteResult
	Read() []score.Score
	Close()
}

// func AddToFireStore(ctx context.Context, projectID string) {
// 	const isTest = false
// 	var repo ScoresRepository = repository.BuildScores(
// 		ctx,
// 		projectID,
// 		isTest,
// 	)
// }
