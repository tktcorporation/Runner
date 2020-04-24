using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{
    public int powerLevel;
    public int jumpPowerLevel;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.AddForce(movement * powerLevel);

        float jump = Input.GetAxis("Vertical");
        Vector2 jumpMovement = new Vector2(0.0f, jump);
        rb.AddForce(jumpMovement * jumpPowerLevel);
    }
}
