using UnityEngine;

public class Manager : MonoBehaviour
{
    public static StatusMap status;
    public static GameSystem.Score score;
    static GameOverCanvas gameOverCanvas;
    public GameObject playerObject;
    Player.Base player;
    Failing.Controller failController;
    static GameSystem.Scene scene;

    public static void GameOver()
    {
        status = StatusMap.overed;
        gameOverCanvas = new GameOverCanvas(Instantiate(GameOverCanvas.GetPrefab()), Retry);
    }
    static void Retry()
    {
        Destroy(gameOverCanvas.obj);
        scene = new GameSystem.Scene(GameSystem.Scene.ScenesMap.Main);
        score = new GameSystem.Score();
        status = StatusMap.playing;
    }

    void PlayerFailCheck()
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

    // LifeCycle Methods
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        status = StatusMap.playing;
        score = new GameSystem.Score();
        player = new Player.Base(playerObject.transform, playerObject.GetComponent<Rigidbody>());
        failController = new Failing.Controller(player, -100f);
    }
    private void LateUpdate()
    {
        PlayerFailCheck();
    }
}