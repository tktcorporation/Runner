using System;
using System.Collections.Generic;
namespace GameSystem
{
    public class Score
    {
        static List<int> scoreHistories = new List<int>();
        public int coinPoints { get; private set; } = 0;
        public Points.Distance distancePoints { get; private set; }

        public Score(Points.Distance distancePoints) {
            this.distancePoints = distancePoints;
        }
        public Score(int initialCoinPoints, Points.Distance distancePoints) {
            this.coinPoints = initialCoinPoints;
            this.distancePoints = distancePoints;
        }
        public int AddCoinPoints(int value)
        {
            this.coinPoints += value;
            return this.coinPoints;
        }
        public void SavaToHistories()
            => scoreHistories.Add(GetTotalPoints());
        public int GetTotalPoints()
            => coinPoints + distancePoints.GetPoints();
        public static List<int> GetHighest5()
        {
            scoreHistories.Sort();
            scoreHistories.Reverse();
            if (scoreHistories.Count < 5)
                return scoreHistories;
            return scoreHistories.GetRange(0, 5);
        }
    }
}
