package collection

// Scores collection for firestore
type Scores int

const (
	ScoresPrd Scores = iota
	ScoresDev
)

func (c Scores) String() string {
	switch c {
	case ScoresPrd:
		return "scores"
	case ScoresDev:
		return "scores_dev"
	default:
		return "unknown"
	}
}
