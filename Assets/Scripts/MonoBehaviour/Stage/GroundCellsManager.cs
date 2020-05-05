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
                Object.Stage.GroundCell.GeneratePerInteravlByProbabilities(
                    intervalSeconds,
                    probabilitiesPercentage,
                    cell,
                    scale,
                    startPositionX,
                    positionY
                )
            );
        }
    }
}

