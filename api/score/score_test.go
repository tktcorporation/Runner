package score

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestScore(t *testing.T) {
	ofDistance := 10
	ofCoin := 15
	userName := "test"

	t.Run("read", func(t *testing.T) {
		score := Create(userName, Points{
			OfCoin:     &ofCoin,
			OfDistance: &ofDistance,
		})

		assert.Equal(t, ofCoin, *score.Points.OfCoin)
		assert.Equal(t, ofDistance, *score.Points.OfDistance)
		assert.Equal(t, "test", *score.UserName)
	})

	t.Run("Create", func(t *testing.T) {
		score := Create(userName, Points{
			OfCoin:     &ofCoin,
			OfDistance: &ofDistance,
		})
		t.Logf("(%%#v) %#v\n", score)
		assert.Equal(t, ofCoin, *score.Points.OfCoin)
		assert.Equal(t, ofDistance, *score.Points.OfDistance)
		assert.Equal(t, "test", *score.UserName)
	})
}
