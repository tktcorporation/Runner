using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultPointsController : MonoBehaviour
{
    void Start()
        => new UI.ResultPointsText(gameObject.GetComponent<Text>(), Manager.score.GetTotalPoints());
}
