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
            new Running.ForceMap(70, 50, 17),
            new Jumping.ForceMap(2500f, 10f)
        );
        octopus.ChangePosition(startPosition);
    }
    void FixedUpdate()
    {
        octopus.Run(Input.GetAxis("Horizontal"));
        octopus.Jump(Input.GetKeyDown(KeyCode.Space));
    }
}