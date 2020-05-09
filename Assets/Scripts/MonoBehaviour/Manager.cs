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
        player = new Player.Base(playerObject.transform, playerObject.GetComponent<Rigidbody>());
        score = new GameSystem.Score(new GameSystem.Points.Distance(new Vector3(0, 0, 0), playerObject.transform));
        failController = new Failing.Controller(player, -100f);
        status = StatusMap.playing;
    }

    void PlayerFailCheck()
    {
        if (!failController.IsFailed())
            return;
        if (Manager.status == Manager.StatusMap.overed)
            return;
        GameOver();
        player.ChangePosition(OctopusController.startPosition);
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
        score = new GameSystem.Score(new GameSystem.Points.Distance(new Vector3(0, 0, 0), playerObject.transform));
        player = new Player.Base(playerObject.transform, playerObject.GetComponent<Rigidbody>());
        failController = new Failing.Controller(player, -100f);
        GameSystem.Score.GetHighest5();
    }
    private void LateUpdate()
    {
        score.distancePoints.UpdatePoints();
        PlayerFailCheck();
    }
}