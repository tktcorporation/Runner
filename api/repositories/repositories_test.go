package repositories

import (
	"context"
	"os"
	"testing"

	firestoreconf "github.com/tktcorporation/Runner/firestore"
	score "github.com/tktcorporation/Runner/score"
)

func TestRepository(t *testing.T) {
	ofDistance := 10
	ofCoin := 15
	userName := "test"
	t.Run("add", func(t *testing.T) {
		ctx := context.Background()
		client := firestoreconf.GetClient(ctx, os.Getenv("PROJECT_ID"))
		score := score.Create(userName, score.Points{
			OfDistance: &ofDistance,
			OfCoin:     &ofCoin,
		})
		t.Logf("(%%#v) %#v\n", score)
		res := add(ctx, *client, score)
		t.Logf("doc: %p", res)
	})

	t.Run("read", func(t *testing.T) {
		ctx := context.Background()
		client := firestoreconf.GetClient(ctx, os.Getenv("PROJECT_ID"))
		docs := read(ctx, client)
		t.Logf("doclength: %d", len(docs))
		t.Logf("docs: %p", docs)
		t.Logf("doc: %#v", docs[0])

		// t.Logf("Score.Points.OfCoin: %d", *docs[0].Points.OfCoin)
		// t.Logf("Score.Points.OfDistance: %d", *docs[0].Points.OfDistance)
		// t.Logf("Score.UserName: %s", *docs[0].UserName)

		// assert.Equal(t, ofCoin, *docs[0].Points.OfCoin)
		// assert.Equal(t, ofDistance, *docs[0].Points.OfDistance)
		// assert.Equal(t, userName, *docs[0].UserName)
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
