using UnityEngine;
using System.Collections;

namespace Object.Stage
{
    public class GroundCell : Base
    {
        public static IEnumerator GeneratePerInteravlByProbabilities(
            float intervalSeconds,
            float probabilitiesPercentage,
            GameObject groundCell,
            Vector3 scale,
            float startPositionX,
            float positionY
        )
        {
            float putPositionX = startPositionX;
            while (true)
            {
                yield return new WaitForSeconds(intervalSeconds);
                GenerateByProbabilities(
                    probabilitiesPercentage,
                    groundCell,
                    scale,
                    putPositionX,
                    positionY
                );
                putPositionX += scale.x;
            }
        }
        static void GenerateByProbabilities(
            float probabilitiesPercentage,
            GameObject groundCell,
            Vector3 scale,
            float positionX,
            float positionY
        )
        {
            if (probabilitiesPercentage < Random.value)
                return;
            Generate(
                groundCell,
                scale,
                positionX,
                positionY
            );
        }
        static void Generate(
            GameObject groundCell,
            Vector3 scale,
            float positionX,
            float positionY
        )
        {
            GameObject clone = UnityEngine.Object.Instantiate(groundCell);
            new Object.Stage.GroundCell(clone, scale).ChangePosition(
                new Vector3(
                    positionX,
                    positionY,
                    0
                )
            );
        }

        public GroundCell(
            GameObject gameObject,
            Vector3 Scale
        ) : base(gameObject.transform)
        {
            gameObject.transform.localScale = Scale;
        }
    }
}

