using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{
    public static Vector3 startPosition = new Vector3(0, 3, 0);
    Player.Octopus octopus;

    // Life cycle method
    void Start()
    {
        octopus = new Player.Octopus(
            transform,
            GetComponent<Rigidbody>(),
            new Running.ForceMap(),
            new Jumping.ForceMap()
        );
        octopus.ChangePosition(startPosition);
    }
    void FixedUpdate()
    {
        octopus.Run(Input.GetAxis("Horizontal"));
        octopus.Jump(Input.GetKeyDown(KeyCode.Space));
    }
    private void LateUpdate()
    {
        new FailController(octopus).Check();
    }
}