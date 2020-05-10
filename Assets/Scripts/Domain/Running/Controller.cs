using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Running
{
    public class Controller
    {
        private Player.Base player;
        private ForceMap forceMap;

        public Controller(Player.Base player, ForceMap ForceMap)
        {
            this.player = player;
            forceMap = ForceMap;
        }

        public void Move(float moveHorizontal)
        {
            if (moveHorizontal > 1)
                moveHorizontal = 1;
            if (moveHorizontal < -1)
                moveHorizontal = -1;
            Vector2 movement = new Vector2(moveHorizontal, 0.0f);
            if (IsOverMaxSpeed())
                player.rigidbody.AddForce(movement * forceMap.Force);
            player.transform.position += new Vector3(forceMap.Speed * Time.deltaTime * moveHorizontal, 0, 0);
        }

        private bool IsOverMaxSpeed()
        {
            float speedX = Mathf.Abs(player.rigidbody.velocity.x);
            if (speedX < forceMap.Threshold)
                return false;
            return true;
        }
    }
}
