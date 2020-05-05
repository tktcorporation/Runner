using System.Collections;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static string prefabPath = "Item/Coin";
    GameObject coin;
    static float generateInterval = 3f;
    static int generateHeight = 20;
    static int randamRangeMin = 1;
    static int randamRangeMax = 40;

    void Start()
    {
        coin = Object.Item.Coin.GetPrefab(prefabPath);
        StartCoroutine(
            Object.Base.LoopActionWithInterval(
                generateInterval,
                () => Object.Item.Coin.Generate(
                    coin,
                    randamRangeMin,
                    randamRangeMax,
                    generateHeight
                )
            )
        );
    }
}
