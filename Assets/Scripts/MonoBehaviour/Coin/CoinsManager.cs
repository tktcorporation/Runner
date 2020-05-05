using System.Collections;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static string prefabPath = "Item/Coin";
    GameObject coin;
    static float generateInterval = 0.1f;
    static int generatedY = 20;
    static int putInterval = 5;
    static int startPositionX = 5;
    static float probabilitiesPercentage = 0.5f;

    void Start()
    {
        coin = Object.Item.Coin.GetPrefab(prefabPath);
        StartCoroutine(
            Object.Base.LoopActionWithIntervalAndStartPositionX(
                (positionX) =>
                    Object.Base.ActionByProbabilities(
                        probabilitiesPercentage,
                        () => Object.Item.Coin.Generate(
                            coin,
                            positionX,
                            generatedY
                        )
                    ),
                generateInterval,
                putInterval,
                startPositionX
            )
        );
    }
}
