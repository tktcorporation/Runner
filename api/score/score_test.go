package score

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestScore(t *testing.T) {

	t.Run("read", func(t *testing.T) {
		score := Create("test", Points{
			OfCoin:     10,
			OfDistance: 10,
		})

		assert.Equal(t, 10, score.Points.OfCoin)
		assert.Equal(t, 10, score.Points.OfCoin)
		assert.Equal(t, "test", score.UserName)
	})

	t.Run("Create", func(t *testing.T) {
		score := Create("test", Points{
			OfCoin:     10,
			OfDistance: 10,
		})
		t.Logf("(%%#v) %#v\n", score)
		assert.Equal(t, 10, score.Points.OfCoin)
		assert.Equal(t, 10, score.Points.OfCoin)
		assert.Equal(t, "test", score.UserName)
	})
}
