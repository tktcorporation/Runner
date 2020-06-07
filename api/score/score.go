package score

import "time"

// Points is a struct for each types of point
type Points struct {
	OfDistance *int `json:"of_distance"`
	OfCoin     *int `json:"of_coin"`
}

// Score is a struct for storing a Score
type Score struct {
	UserName  *string `json:"user_name"`
	Points    *Points `json:"points"`
	Timestamp *int64  `json:"timestamp"`
}

// Create is for create a score struct
func Create(
	userName string,
	points Points,
) Score {
	timestamp := time.Now().Unix()
	return Score{
		UserName:  &userName,
		Points:    &points,
		Timestamp: &timestamp,
	}
}
