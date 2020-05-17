// Package helloworld provides a set of Cloud Functions samples.
package helloworld

import (
	"context"
	"encoding/json"
	"fmt"
	"html"
	"net/http"
	"os"

	"github.com/tktcorporation/Runner/repositories"
)

// HelloHTTP is an HTTP Cloud Function with a request parameter.
func HelloHTTP(w http.ResponseWriter, r *http.Request) {
	var d struct {
		Name string `json:"name"`
	}
	if err := json.NewDecoder(r.Body).Decode(&d); err != nil {
		ctx := context.Background()
		projectID := os.Getenv("PROJECT_ID")
		writeResult := new(repositories.UsersRepository).Add(ctx, projectID)
		fmt.Fprint(w, writeResult.UpdateTime)
		return
	}
	if d.Name == "" {
		fmt.Fprint(w, "Hello, World!")
		return
	}
	fmt.Fprintf(w, "Hello, %s!", html.EscapeString(d.Name))
}
