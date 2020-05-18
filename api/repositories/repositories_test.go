package repositories

import (
	"context"
	"os"
	"testing"
	"time"

	firestoreconf "github.com/tktcorporation/Runner/firestore"
	score "github.com/tktcorporation/Runner/score"
)

func TestRepository(t *testing.T) {

	t.Run("add", func(t *testing.T) {
		ctx := context.Background()
		client := firestoreconf.GetClient(ctx, os.Getenv("PROJECT_ID"))
		score := score.Score{
			UserName: "test",
			Points: score.Points{
				OfDistance: 10,
				OfCoin:     36,
			},
			Timestamp: time.Now().Unix(),
		}
		res := add(ctx, *client, score)
		t.Logf("doc: %p", res)
	})

	t.Run("read", func(t *testing.T) {
		ctx := context.Background()
		client := firestoreconf.GetClient(ctx, os.Getenv("PROJECT_ID"))
		doc, err := read(ctx, client)
		if err != nil {
			t.Log(doc)
			t.Logf("err: %p", doc)
		}
		t.Logf("doc: %p", err)

		// assert.Equal(t, id, user.ID)
		// assert.Equal(t, name, user.Name)
		// assert.Equal(t, email, user.Email)

		// t.Logf("user: %p", user)
		// t.Logf("user.ID: %d", user.ID)
		// t.Logf("user.Name: %s", user.Name)
		// t.Logf("user.Email: %s", user.Email)
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
