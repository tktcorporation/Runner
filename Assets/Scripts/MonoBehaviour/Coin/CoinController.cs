using UnityEngine;

public class CoinController : MonoBehaviour
{
    Item.Coin coin;

    void Start()
    {
        coin = new Item.Coin(transform, GetComponent<Rigidbody>(), -100);
        coin.ChangePosition(new Vector3(0, 10, 0));
        coin.AddAngularVelocityToX(2f);
    }

    void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        Destroy(gameObject);
        Manager.AddPoints(1);
        Debug.Log(Manager.points);
    }

    private void LateUpdate()
    {
        if (coin.isLoweredDestroyPositionY())
            Destroy(gameObject);
    }

}
