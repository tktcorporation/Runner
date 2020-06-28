using UnityEngine;
using UniRx;

public class GlobalHighScoresController : MonoBehaviour
{
    static string HighScoreHistoryCellPath = "UI/HighScoreHistoryCell";
    static void CreateGlobalHighScores(Transform transform, ScoreHttp.Scores scores)
    {
        int i = 0;
        Debug.Log(scores.items);
        scores.items.ForEach(
            (score) => {
                GameObject obj = Instantiate(Resources.Load<GameObject>(HighScoreHistoryCellPath), transform);
                UI.GlobalHighScoresCell cell = new UI.GlobalHighScoresCell(obj, i, score.user_name, score.total_point);
                i += 1;
            }
        );
    }
    async void Start()
    {
        ScoreHttp scoreHttp = new ScoreHttp();
        ScoreHttp.Scores result = await Observable.FromCoroutine<ScoreHttp.Scores>(observer => scoreHttp.GET(observer));
        CreateGlobalHighScores(transform, result);
    }
}
