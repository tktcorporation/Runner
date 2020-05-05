using UnityEngine;
using System.Collections;

namespace Object.Stage
{
    public class GroundCell : Base
    {
        public static void Generate(
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

