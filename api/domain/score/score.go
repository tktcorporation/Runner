package score

import "time"

// Points is a struct for each types of point
type Points struct {
	OfDistance *int `json:"of_distance" firestore:"of_distance"`
	OfCoin     *int `json:"of_coin" firestore:"of_coin"`
}

// Score is a struct for storing a Score
type Score struct {
	UserName   *string `json:"user_name" firestore:"user_name"`
	Points     *Points `json:"points" firestore:"points"`
	TotalPoint *int    `json:"total_point" firestore:"total_point"`
	Timestamp  *int64  `json:"timestamp" firestore:"timestamp"`
}

// Create is for create a score struct
func Create(
	userName string,
	points Points,
) Score {
	timestamp := time.Now().Unix()
	totalPoint := *points.OfCoin + *points.OfDistance
	return Score{
		UserName:   &userName,
		Points:     &points,
		TotalPoint: &totalPoint,
		Timestamp:  &timestamp,
	}
}
