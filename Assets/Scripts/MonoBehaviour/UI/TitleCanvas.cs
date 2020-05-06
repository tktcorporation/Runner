using UnityEngine;
using System.Collections;
namespace Scene
{
    public class TitleCanvas : MonoBehaviour
    {
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

