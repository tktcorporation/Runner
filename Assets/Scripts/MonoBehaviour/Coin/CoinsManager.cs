using System.Collections;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static string prefabPath = "Item/Coin";
    GameObject coin;
    static int generateHeight = 20;
    static int randamRangeMin = 1;
    static int randamRangeMax = 40;

    IEnumerator Generating()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Generate();
        }
    }
    void Generate()
    {
        GameObject clone = Instantiate(coin);
        new Object.Item.Coin(clone).ChangePosition(
            new Vector3(
                Random.Range(randamRangeMin, randamRangeMax),
                generateHeight,
                0
            )
        );
    }

    // LifeCycle Methods
    void Start()
    {
        coin = Object.Item.Coin.GetPrefab(prefabPath);
        StartCoroutine(Generating());
    }
}
