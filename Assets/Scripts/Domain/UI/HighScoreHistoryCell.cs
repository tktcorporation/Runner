using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HighScoreHistoryCell
    {
        public Text text;
        public HighScoreHistoryCell(GameObject obj, int index, int score)
        {
            this.text = obj.GetComponent<Text>();
            SetText(index, score);
        }
        public HighScoreHistoryCell(Text text, int index,int score)
        {
            this.text = text;
            SetText(index, score);
        }

        void FixPosition(Transform parentTransform, int index)
        {
            text.transform.position = new Vector3(
                parentTransform.position.x,
                parentTransform.position.y - index * text.preferredHeight,
                parentTransform.position.z
            );
        }
        void SetText(int index, int score)
        {
            this.text.text = $"{CreateRankWithPrefix(index + 1)}. {score}pt";
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
