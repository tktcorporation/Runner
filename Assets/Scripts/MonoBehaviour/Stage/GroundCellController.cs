using UnityEngine;
using System.Collections;

public class GroundCellController : MonoBehaviour
{
    void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        Destroy(gameObject);
    }
}
