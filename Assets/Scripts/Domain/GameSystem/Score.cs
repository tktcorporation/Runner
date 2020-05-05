namespace GameSystem
{
    public class Score
    {
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
    }
}
