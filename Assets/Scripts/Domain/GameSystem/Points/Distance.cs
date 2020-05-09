using UnityEngine;
namespace GameSystem
{
    namespace Points
    {
        public class Distance
        {
            Vector3 startPosition = new Vector3(0, 0, 0);
            Transform targetTransform;
            int points = 0;
            int divideNum = 100;
            public Distance(Vector3 startPosition, Transform targetTransform)
            {
                this.startPosition = startPosition;
                this.targetTransform = targetTransform;
            }
            public Distance(Vector3 startPosition, Transform targetTransform, int divideNum)
            {
                this.startPosition = startPosition;
                this.targetTransform = targetTransform;
                this.divideNum = divideNum;
            }
            public void UpdatePoints()
                => this.points = (int)((targetTransform.position.x - startPosition.x) / divideNum);
            public int GetPoints()
                => this.points;
            public int UpdateAndGetPoints()
            {
                UpdatePoints();
                return GetPoints();
            }
        }
    }
}