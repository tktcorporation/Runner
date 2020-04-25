using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    // after Update
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, initialPosition.y, initialPosition.z);
    }
}
