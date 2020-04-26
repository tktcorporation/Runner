using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController
{
    private Rigidbody2D rb;

    public MoveController(Rigidbody2D r)
    {
        rb = r;
    }

    public void Move(float moveHorizontal, int powerLevel)
    {
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.AddForce(movement * powerLevel);
    }
}
