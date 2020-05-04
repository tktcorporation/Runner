using UnityEngine;
namespace Item
{
    public class Coin : Base
    {
        public static GameObject GetPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }

        Rigidbody rigidbody;
        int destroyPositionY = -100;
        public Coin(
            Transform transform,
            Rigidbody rigidbody,
            int destroyPositionY
        ) : base(transform)
        {
            this.rigidbody = rigidbody;
            this.destroyPositionY = destroyPositionY;
        }
        public Coin(
            GameObject gameObject
        ) : base(gameObject.transform)
        {
            this.rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        public bool isLoweredDestroyPositionY()
        {
            if (transform.position.y > destroyPositionY)
                return false;
            return true;
        }
        public void AddAngularVelocityToX(float velocity)
        {
            AddAngularVelocity(new Vector3(0f, velocity, 0f));
        }
        void AddAngularVelocity(Vector3 vector3)
        {
            rigidbody.angularVelocity = vector3;
        }

    }
}
