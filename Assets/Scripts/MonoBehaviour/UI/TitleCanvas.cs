using UnityEngine;
using UnityEngine.UI;

namespace Scene
{
    public class TitleCanvas : MonoBehaviour
    {
        public InputField inputField;

        public void ChangeName()
        {
            Manager.ChangeName(this.inputField.text);
        }
        public void LoadMainScene()
        {
            GameSystem.Scene.BuildWithLoadScene(GameSystem.Scene.ScenesMap.Main);
        }
        void Start()
        {
            new UI.TitleCanvas(gameObject, LoadMainScene);
        }
    }
}

