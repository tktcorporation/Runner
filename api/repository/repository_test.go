package repository

import (
	"context"
	"encoding/json"
	"os"
	"testing"

	score "github.com/tktcorporation/Runner/domain/score"
)

func TestRepository(t *testing.T) {
	ofDistance := 10
	ofCoin := 15
	userName := "testandadminuser"
	t.Run("add", func(t *testing.T) {
		ctx := context.Background()
		score := score.Create(userName, score.Points{
			OfDistance: &ofDistance,
			OfCoin:     &ofCoin,
		})
		t.Logf("(%%#v) %#v\n", score)
		repo := BuildScores(ctx, os.Getenv("PROJECT_ID"), true)
		res := repo.Add(score)
		t.Logf("doc: %p", res)
	})

	t.Run("read", func(t *testing.T) {
		ctx := context.Background()
		repo := BuildScores(ctx, os.Getenv("PROJECT_ID"), true)
		docs := repo.Read()
		t.Logf("doclength: %d", len(docs))
		t.Logf("docs: %p", docs)
		t.Logf("doc: %#v", docs[0])
		t.Logf("doc: %#v", *docs[0].UserName)
		t.Logf("doc: %#v", *docs[0].Points)
	})

	t.Run("Read", func(t *testing.T) {
		ctx := context.Background()
		repo := BuildScores(ctx, os.Getenv("PROJECT_ID"), true)
		scores := repo.Read()
		// t.Logf("json: %#v", scores)
		// t.Logf("UserName: %#v", *scores[0].UserName)
		// t.Logf("Points: %#v", *scores[0].Points)
		// t.Logf("Timestamp: %#v", *scores[0].Timestamp)
		scoresJSON, _ := json.Marshal(scores)
		t.Logf("json: %#v", (string)(scoresJSON))
	})

	// t.Run("success NewUser()", func(t *testing.T) {
	// 	var id int64 = 2
	// 	var name string = "Suzuki"
	// 	var email string = "suzuki@example.com"
	// 	user := NewUser(id, name, email)

	// 	if user == nil {
	// 		t.Errorf("failed NewUser()")
	// 	}

	// 	assert.Equal(t, id, user.ID)
	// 	assert.Equal(t, name, user.Name)
	// 	assert.Equal(t, email, user.Email)

	// 	t.Logf("user: %p", user)
	// 	t.Logf("user.ID: %d", user.ID)
	// 	t.Logf("user.Name: %s", user.Name)
	// 	t.Logf("user.Email: %s", user.Email)
	// })
}
