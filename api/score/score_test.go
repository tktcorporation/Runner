package score

import (
	"testing"
	"github.com/stretchr/testify/assert"
)

func TestRepository(t *testing.T) {

	t.Run("read", func(t *testing.T) {
		score := Create("test", Points{
			OfCoin:     10,
			OfDistance: 10,
		})

		assert.Equal(t, 10, score.Points.OfCoin)
		assert.Equal(t, 10, score.Points.OfCoin)
		assert.Equal(t, "test", score.UserName)
	})
}
