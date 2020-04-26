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
        new MoveController(rb).Move(Input.GetAxis("Horizontal"), powerLevel);
        new JumpController(rb, transform).Jump(Input.GetKeyDown(KeyCode.Space));
    }

    class ForceMap
    {
        public static float jumpForce = 22f;
        public static float jumpThreshold = 1f;
        public static float runForce = 1.5f;
        public static float runSpeed = 0.5f;
        public static float runThreshold = 2.2f;
    }
}