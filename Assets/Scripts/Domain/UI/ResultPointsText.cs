using UnityEngine.UI;
namespace UI
{
    public class ResultPointsText
    {
        Text text;
        public ResultPointsText(Text text, int points)
        {
            this.text = text;
            this.text.text = CreateResultPointsText(points);
        }
        string CreateResultPointsText(int points)
            => $"Result: {points}pt";
    }
}
