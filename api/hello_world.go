// Package helloworld provides a set of Cloud Functions samples.
package helloworld

import (
	"context"
	"encoding/json"
	"fmt"
	"html"
	"net/http"
	"os"
	"time"

	"github.com/tktcorporation/Runner/repositories"
	"github.com/tktcorporation/Runner/score"
)

// HelloHTTP is an HTTP Cloud Function with a request parameter.
func HelloHTTP(w http.ResponseWriter, r *http.Request) {
	var d struct {
		Name string `json:"name"`
	}
	if err := json.NewDecoder(r.Body).Decode(&d); err != nil {
		ctx := context.Background()
		projectID := os.Getenv("PROJECT_ID")
		score := score.Score{
			UserName: "admin",
			Points: score.Points{
				OfDistance: 10,
				OfCoin:     36,
			},
			Timestamp: time.Now().Unix(),
		}
		writeResult := new(repositories.UsersRepository).Add(ctx, projectID, score)
		fmt.Fprint(w, projectID+": "+writeResult.UpdateTime.String())
		return
	}
	if d.Name == "" {
		fmt.Fprint(w, "Hello, World!")
		return
	}
	fmt.Fprintf(w, "Hello, %s!", html.EscapeString(d.Name))
}
