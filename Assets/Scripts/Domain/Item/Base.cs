using UnityEngine;

namespace Item
{
    public class Base
    {
        public Transform transform;
        //Collider collider;
        //Rigidbody rigidbody;

        public Base(Transform transform)
        {
            this.transform = transform;
        }
        //public Base3D(Transform transform, Collider collider)
        //{
        //    this.transform = transform;
        //    this.collider = collider;
        //}
        //public Base3D(Transform transform, Collider collider, Rigidbody rigidbody)
        //{
        //    this.transform = transform;
        //    this.collider = collider;
        //    this.rigidbody = rigidbody;
        //}

        public void ChangePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
