using UnityEngine.UI;
namespace UI
{
    public class PointsText
    {
        Text text;
        public PointsText(Text text)
        {
            this.text = text;
        }
        public void updateText(string text)
        {
            this.text.text = text;
        }
    }
}
