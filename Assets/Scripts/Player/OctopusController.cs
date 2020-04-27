using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        new RunController(rb, transform).Move(Input.GetAxis("Horizontal"));
        new JumpController(rb, transform).Jump(Input.GetKeyDown(KeyCode.Space));
    }

    private void LateUpdate()
    {
        new FailController(transform).Check();
    }
}