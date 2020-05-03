namespace Running
{
    public class ForceMap
    {
        public float Force = 30f;
        public float Speed = 20f;
        public float Threshold = 17f;

        public ForceMap() { }
        public ForceMap(float force, float speed, float threshold)
        {
            Force = force;
            Speed = speed;
            Threshold = threshold;
        }
    }
}

