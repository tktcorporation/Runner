package repositories

import (
	"context"
	"os"
	"testing"
)

func TestRepository(t *testing.T) {

	t.Run("read", func(t *testing.T) {
		ctx := context.Background()
		client := getFirestoreClient(ctx, os.Getenv("PROJECT_ID"))
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
