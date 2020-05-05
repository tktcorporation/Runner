using System;
using UnityEngine;
using System.Collections;

namespace Object
{
    public class Base
    {
        public static GameObject GetPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
        public static IEnumerator LoopActionWithIntervalAndStartPositionX(
            Action action,
            float intervalSeconds,
            float xAddingPerAction,
            float startPositionX
        )
        {
            float putPositionX = startPositionX;
            while (true)
            {
                yield return new WaitForSeconds(intervalSeconds);
                action();
                putPositionX += xAddingPerAction;
            }
        }
        // 使用できない
        // public static IEnumerator LoopAction(Action action)
        // {
        //     while (true)
        //     {
        //         action();
        //     }
        // }
        public static IEnumerator LoopActionWithInterval(
            float intervalSeconds,
            Action action
        )
        {
            while (true)
            {
                yield return new WaitForSeconds(intervalSeconds);
                action();
            }
        }
        public static void ActionByProbabilities(
            float probabilitiesPercentage,
            Action action
        )
        {
            if (probabilitiesPercentage < UnityEngine.Random.value)
                return;
            action();
        }

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
