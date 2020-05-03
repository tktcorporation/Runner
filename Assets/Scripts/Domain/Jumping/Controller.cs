using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumping
{
    public class Controller
    {
        ForceMap forceMap;
        Player.Base player;

        public Controller(Player.Base player, ForceMap forceMap)
        {
            this.forceMap = forceMap;
            this.player = player;
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
            if (Mathf.Abs(player.rigidbody.velocity.y) > forceMap.jumpThreshold)
                return false;
            return true;
        }

        private void AddForce()
        {
            player.rigidbody.AddForce(player.transform.up * forceMap.jumpForce);
        }
    }
}
