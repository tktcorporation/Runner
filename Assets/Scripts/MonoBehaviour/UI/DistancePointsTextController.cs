using UnityEngine;
using UnityEngine.UI;

public class DistancePointsTextController : MonoBehaviour
{
    UI.PointsText pointsText;
    void Start()
    {
        pointsText = new UI.PointsText(GetComponent<Text>());
    }
    void LateUpdate()
    {
        pointsText.updateText(Manager.score.distancePoints.UpdateAndGetPoints().ToString());
    }
}
