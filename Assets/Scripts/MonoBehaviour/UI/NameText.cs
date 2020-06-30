using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = Manager.playerName;
    }
}