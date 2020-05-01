using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static StatusMap status = StatusMap.playing;
    static GameObject gameOverCanvas;
    static Button retryButton;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void GameOver()
    {
        status = StatusMap.overed;
        gameOverCanvas = Instantiate(Resources.Load<GameObject>("UI/GameOverCanvas"));
        retryButton = gameOverCanvas.GetComponentsInChildren<Button>()[0];
        retryButton.onClick.AddListener(Retry);
    }

    public static void Retry()
    {
        Destroy(gameOverCanvas);
        WaitForLoadScene(ScenesMap.Main);
        status = StatusMap.playing;
    }

    static IEnumerator WaitForLoadScene(string sceneName)
    {
        //シーンを非同期で読込し、読み込まれるまで待機する
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    public enum StatusMap
    {
        playing = 0,
        overed = 1
    }

    class ScenesMap
    {
        public static string Main = "MainScene";
    }
}