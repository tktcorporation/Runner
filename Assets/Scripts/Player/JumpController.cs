using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController
{
    private Rigidbody2D rb;
    private Transform transform;

    public JumpController(Rigidbody2D r, Transform t)
    {
        rb = r;
        transform = t;
    }

    public void Jump(bool keydown)
    {
        if (!keydown)
            return;
        if (!isEnableToJump())
            return;
        AddForce();
    }

    private bool isEnableToJump()
    {
        if (Mathf.Abs(rb.velocity.y) > ForceMap.jumpThreshold)
            return false;
        return true;
    }

    private void AddForce()
    {
        rb.AddForce(transform.up * ForceMap.jumpForce);
    }

    class ForceMap
    {
        public static float jumpForce = 2000f;
        public static float jumpThreshold = 1f;
    }
}
