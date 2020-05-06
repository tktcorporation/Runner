using System;
using System.Collections.Generic;
namespace GameSystem
{
    public class Score
    {
        static List<int> scoreHistories = new List<int>();
        public int coinPoints { get; private set; } = 0;

        public Score() { }
        public Score(int initialCoinPoints) {
            this.coinPoints = initialCoinPoints;
        }
        public int AddCoinPoints(int value)
        {
            this.coinPoints += value;
            return this.coinPoints;
        }
        public void SavaToHistories()
        {
            scoreHistories.Add(coinPoints);
        }
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
