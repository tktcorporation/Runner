using System;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static StatusMap status;
    public static GameSystem.Score score;
    static GameOverCanvas gameOverCanvas;
    public GameObject playerObject;
    static Player.Base player;
    static Failing.Controller failController;

    public static void ManagerAction(Action action)
    {
        action();
    }
    public void GameOver()
    {
        status = StatusMap.overed;
        score.SavaToHistories();
        gameOverCanvas = new GameOverCanvas(Instantiate(GameOverCanvas.GetPrefab()), Retry);
    }
    void Retry()
    {
        Destroy(gameOverCanvas.obj);
        GameSystem.Scene.BuildWithLoadScene(GameSystem.Scene.ScenesMap.Main);
        score = new GameSystem.Score();
        player = new Player.Base(playerObject.transform, playerObject.GetComponent<Rigidbody>());
        failController = new Failing.Controller(player, -100f);
        status = StatusMap.playing;
    }

    void PlayerFailCheck()
    {
        if (!failController.IsFailed())
            return;
        if (Manager.status == Manager.StatusMap.overed)
            return;
        player.ChangePosition(OctopusController.startPosition);
        GameOver();
    }

    public enum StatusMap
    {
        playing = 0,
        overed = 1
    }

    // LifeCycle Methods
    void Start()
    {
        status = StatusMap.playing;
        score = new GameSystem.Score();
        player = new Player.Base(playerObject.transform, playerObject.GetComponent<Rigidbody>());
        failController = new Failing.Controller(player, -100f);
        GameSystem.Score.GetHighest5();
    }
    private void LateUpdate()
    {
        PlayerFailCheck();
    }
}