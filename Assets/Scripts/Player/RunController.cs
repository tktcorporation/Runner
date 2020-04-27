using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController
{
    private Rigidbody2D rb;
    private Transform transform;

    public RunController(Rigidbody2D r, Transform t)
    {
        rb = r;
        transform = t;
    }

    public void Move(float moveHorizontal)
    {
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        if (IsOverMaxSpeed())
            rb.AddForce(movement * ForceMap.runForce);
        transform.position += new Vector3(ForceMap.runSpeed * Time.deltaTime * moveHorizontal, 0, 0);
    }

    private bool IsOverMaxSpeed()
    {
        float speedX = Mathf.Abs(rb.velocity.x);
        if (speedX < ForceMap.runThreshold)
            return false;
        return true;
    }

    class ForceMap
    {
        public static float runForce = 30f;
        public static float runSpeed = 20f;
        public static float runThreshold = 17f;
    }
}
