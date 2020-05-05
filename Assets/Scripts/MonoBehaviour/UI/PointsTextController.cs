using UnityEngine;
using UnityEngine.UI;

public class PointsTextController : MonoBehaviour
{
    UI.PointsText pointsText;
    void Start()
    {
        pointsText = new UI.PointsText(GetComponent<Text>());
    }
    void LateUpdate()
    {
        pointsText.updateText(Manager.score.coinPoints.ToString());
    }
}
