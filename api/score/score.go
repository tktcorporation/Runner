package score

import "time"

// Points is a struct for each types of point
type Points struct {
	OfDistance int `firestore:"of_distance"`
	OfCoin     int `firestore:"of_coin"`
}

// Score is a struct for storing a Score
type Score struct {
	UserName  string `firestore:"user_name"`
	Points    Points `firestore:"points"`
	Timestamp int64  `firestore:"timestamp"`
}

// Create is for create a score struct
func Create(
	userName string,
	points Points,
) Score {
	return Score{
		UserName:  userName,
		Points:    points,
		Timestamp: time.Now().Unix(),
	}
}
