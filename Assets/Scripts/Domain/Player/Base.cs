using UnityEngine;
namespace Player
{
    public class Base
    {
        public Transform transform;
        public Rigidbody rigidbody;

        public Base(Transform transform, Rigidbody rigidbody)
        {
            this.transform = transform;
            this.rigidbody = rigidbody;
        }
        public void ChangePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}

