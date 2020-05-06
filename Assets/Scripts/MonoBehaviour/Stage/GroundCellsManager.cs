using UnityEngine;
using System.Collections;
namespace Stage
{
    public class GroundCellsManager : MonoBehaviour
    {
        public static string prefabPath = "Stage/Ground/Cell";
        GameObject cell;
        public static float intervalSeconds = 0.1f;
        public static float probabilitiesPercentage = 0.8f;
        public static Vector3 scale = new Vector3(5,5,20);
        public static float startPositionX = 1;
        public static float positionY = -2.5f;

        void Start()
        {
            cell = Object.Base.GetPrefab(prefabPath);
            StartCoroutine(
                Object.Base.LoopActionWithIntervalAndStartPositionX(
                    (positionX) => Object.Base.ActionByProbabilities(
                        probabilitiesPercentage,
                        () => Object.Stage.GroundCell.Generate(
                            cell,
                            scale,
                            positionX,
                            positionY
                        )
                    ),
                    intervalSeconds,
                    scale.x,
                    startPositionX
                )
            );
        }
        void OnCollisionExit(Collision other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            Destroy(gameObject);
        }
        private void LateUpdate()
        {
            if (Manager.status == Manager.StatusMap.overed)
                StopAllCoroutines();
        }
    }
}

