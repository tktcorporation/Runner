using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    class TitleCanvas
    {
        public GameObject canvas;

        public TitleCanvas(GameObject canvas, UnityEngine.Events.UnityAction func)
        {
            this.canvas = canvas;
            AddListenerToFirstButton(func);
        }
        void AddListenerToFirstButton(UnityEngine.Events.UnityAction func)
        {
            GetFirstButton().onClick.AddListener(func);
        }
        Button GetFirstButton()
        {
            Debug.Log(GetButtons()[0]);
            return GetButtons()[0];
        }
        Button[] GetButtons()
        {
            return canvas.GetComponentsInChildren<Button>();
        }
    }

}