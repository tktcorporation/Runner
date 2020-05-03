using System;
namespace Jumping
{
    public class ForceMap
    {
        public float jumpForce = 1500f;
        public float jumpThreshold = 0.5f;

        public ForceMap() { }
        public ForceMap(float JumpForce, float JumpThreshold)
        {
            jumpForce = JumpForce;
            jumpThreshold = JumpThreshold;
        }
    }
}
