using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GlobalHighScoresCell
    {
        public Text text;
        public GlobalHighScoresCell(GameObject obj, int index, string name, int score)
        {
            this.text = obj.GetComponent<Text>();
            SetText(index, name, score);
        }
        public GlobalHighScoresCell(Text text, int index, string name, int score)
        {
            this.text = text;
            SetText(index, name, score);
        }

        void FixPosition(Transform parentTransform, int index)
        {
            text.transform.position = new Vector3(
                parentTransform.position.x,
                parentTransform.position.y - index * text.preferredHeight,
                parentTransform.position.z
            );
        }
        void SetText(int index, string name, int score)
        {
            this.text.text = $"{CreateRankWithPrefix(index + 1)}. {name} {score}pt";
        }
        static string  CreateRankWithPrefix(int rank)
        {
            switch (rank)
            {
                case 1:
                    return $"{rank}st";
                case 2:
                    return $"{rank}nd";
                case 3:
                    return $"{rank}rd";
                default:
                    return $"{rank}th";
            }
        }
    }
}
