using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Octopus : Base
    {
        Running.Controller runningController;
        Jumping.Controller jumpingController;

        public Octopus(
            Transform t,
            Rigidbody r,
            Running.ForceMap rForceMap,
            Jumping.ForceMap jForceMap
        ) : base(t,r)
        {
            runningController = new Running.Controller(this, rForceMap);
            jumpingController = new Jumping.Controller(this, jForceMap);
        }
        public void Run(float moveHorizontal)
        {
            runningController.Move(moveHorizontal);
        }
        public void Jump(bool execute)
        {
            jumpingController.Jump(execute);
        }
    }
}