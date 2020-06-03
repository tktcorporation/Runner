package scorehttp

import (
	"context"
	"encoding/json"
	"fmt"
	"html"
	"net/http"
	"os"

	"github.com/tktcorporation/Runner/repositories"
	"github.com/tktcorporation/Runner/score"
)

// StoreScoreHTTP is an HTTP Cloud Function with a request parameter.
func StoreScoreHTTP(w http.ResponseWriter, r *http.Request) {
	type Points struct {
		OfDistance int `json:"of_distance"`
		OfCoin     int `json:"of_coin"`
	}
	var d struct {
		UserName string `json:"user_name"`
		Points   Points `json:"points"`
	}
	err := json.NewDecoder(r.Body).Decode(&d)
	if err != nil {
		w.WriteHeader(http.StatusBadRequest)
		w.Header().Set("Content-Type", "application/json")
		fmt.Fprintf(w, "Bad Request received!: %s", html.EscapeString(err.Error()))
		return
	}
	ctx := context.Background()
	projectID := os.Getenv("PROJECT_ID")
	writeResult := (&repositories.UsersRepository{
		Context:   ctx,
		ProjectID: projectID,
	}).Add(
		score.Create(d.UserName, score.Points{
			OfDistance: &d.Points.OfDistance,
			OfCoin:     &d.Points.OfCoin,
		}),
	)
	w.WriteHeader(http.StatusOK)
	fmt.Fprint(w, projectID+": "+writeResult.UpdateTime.String())
}

// ReadScoreHTTP is an HTTP Cloud Function with a request parameter.
func ReadScoreHTTP(w http.ResponseWriter, r *http.Request) {
	// var d struct {
	// 	Limit    string `json:"limit"`
	// 	OrderAsc bool   `json:"order_asc"`
	// }
	// err := json.NewDecoder(r.URL.Query()).Decode(&d)
	// if err != nil {
	// 	w.WriteHeader(http.StatusBadRequest)
	// 	w.Header().Set("Content-Type", "application/json")
	// 	fmt.Fprintf(w, "Bad Request received!: %s", html.EscapeString(err.Error()))
	// 	return
	// }

	usersRepo := &repositories.UsersRepository{
		Context:   context.Background(),
		ProjectID: os.Getenv("PROJECT_ID"),
	}
	scores := usersRepo.Read()
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(scores)
}
