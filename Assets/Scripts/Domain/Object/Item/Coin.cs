using UnityEngine;
using System.Collections;

namespace Object.Item
{
    public class Coin : Base
    {
        public static IEnumerator GeneratePerInteravl(
            float intervalSeconds,
            GameObject coin,
            float randamRangeMinX,
            float randamRangeMaxX,
            float positionY
         )
        {
            while (true)
            {
                yield return new WaitForSeconds(intervalSeconds);
                Generate(
                    coin,
                    randamRangeMinX,
                    randamRangeMaxX,
                    positionY
                );
            }
        }
        static void Generate(
            GameObject coin,
            float randamRangeMinX,
            float randamRangeMaxX,
            float positionY
        )
        {
            GameObject clone = UnityEngine.Object.Instantiate(coin);
            new Object.Item.Coin(clone).ChangePosition(
                new Vector3(
                    Random.Range(randamRangeMinX, randamRangeMaxX),
                    positionY,
                    0
                )
            );
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
