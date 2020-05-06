using UnityEngine;
using System.Collections;

public class HighScoreHistoriesController : MonoBehaviour
{
    static string HighScoreHistoryCellPath = "UI/HighScoreHistoryCell";
    static void CreateHighScoreHistories(Transform transform)
    {
        int i = 0;
        GameSystem.Score.GetHighest5().ForEach(
            (score) => {
                GameObject obj = Instantiate(Resources.Load<GameObject>(HighScoreHistoryCellPath), transform);
                UI.HighScoreHistoryCell cell = new UI.HighScoreHistoryCell(obj, i, score);
                i += 1;
            }
        );
    }
    void Start()
    {
        CreateHighScoreHistories(transform);
    }
}
