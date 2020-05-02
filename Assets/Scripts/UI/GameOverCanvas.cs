﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class GameOverCanvas
{
    public static string Path = "UI/GameOverCanvas";
    public static GameObject GetPrefab()
    {
        return Resources.Load<GameObject>(Path);
    }

    public GameObject obj;

    public GameOverCanvas(GameObject gameOverCanvas, UnityEngine.Events.UnityAction retryFunc)
    {
        obj = gameOverCanvas;
        AddListenerToRetryButton(retryFunc);
    }
    void AddListenerToRetryButton(UnityEngine.Events.UnityAction func)
    {
        GetRetryButton().onClick.AddListener(func);
    }
    Button GetRetryButton()
    {
        return GetButton()[0];
    }
    Button[] GetButton()
    {
        return obj.GetComponentsInChildren<Button>();
    }
}
