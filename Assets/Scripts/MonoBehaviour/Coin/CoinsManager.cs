using System.Collections;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public static string prefabPath = "Item/Coin";
    GameObject coin;

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
        Instantiate(coin);
    }

    // LifeCycle Methods
    void Start()
    {
        coin = Item.Coin.GetPrefab(prefabPath);
        StartCoroutine("Generating");
    }

    void Update()
    {
    }

}
