using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static StatusMap status;
    public static int points;
    static GameOverCanvas gameOverCanvas;
    public GameObject playerObject;
    Player.Base player;
    Failing.Controller failController;

    public static void GameOver()
    {
        status = StatusMap.overed;
        gameOverCanvas = new GameOverCanvas(Instantiate(GameOverCanvas.GetPrefab()), Retry);
    }
    static void Retry()
    {
        WaitForLoadScene(ScenesMap.Main);
        status = StatusMap.playing;
        Destroy(gameOverCanvas.obj);
    }

    static IEnumerator WaitForLoadScene(string sceneName)
    {
        //シーンを非同期で読込し、読み込まれるまで待機する
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    public void PlayerFailCheck()
    {
        if (!failController.IsFailed())
            return;
        if (Manager.status == Manager.StatusMap.overed)
            return;
        player.ChangePosition(OctopusController.startPosition);
        Manager.GameOver();
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

    // LifeCycle Methods
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        status = StatusMap.playing;
        points = 0;
        player = new Player.Base(playerObject.transform, playerObject.GetComponent<Rigidbody>());
        failController = new Failing.Controller(player, -100f);
    }
    private void LateUpdate()
    {
        PlayerFailCheck();
    }
}