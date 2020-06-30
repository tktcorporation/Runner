package scorehttp

import (
	"encoding/json"
	"log"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestScorehttp(t *testing.T) {
	jsonstr := `{"user_name":"GameManager","points":{"of_distance":14,"of_coin":35}}`
	t.Run("decode from json string", func(t *testing.T) {
		var d struct {
			UserName string `json:"user_name"`
			Points   struct {
				OfDistance int `json:"of_distance"`
				OfCoin     int `json:"of_coin"`
			} `json:"points"`
		}
		log.Printf("body: %v", jsonstr)
		err := json.Unmarshal([]byte(jsonstr), &d)
		if err != nil {
			log.Fatalln(err.Error())
		}

		assert.Equal(t, "GameManager", d.UserName)
		assert.Equal(t, 35, d.Points.OfCoin)
		assert.Equal(t, 14, d.Points.OfDistance)
		t.Logf("score: %v", d)
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
