using UnityEngine;

public class CoinController : MonoBehaviour
{
    public Item.Coin coin;

    void Start()
    {
        coin = new Item.Coin(transform, GetComponent<Rigidbody>(), -100);
        coin.AddAngularVelocityToX(2f);
    }

    void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        Destroy(gameObject);
        Manager.score.AddCoinPoints(1);
    }

    private void LateUpdate()
    {
        if (coin.isLoweredDestroyPositionY())
            Destroy(gameObject);
    }

}
