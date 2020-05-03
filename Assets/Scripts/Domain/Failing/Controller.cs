namespace Failing
{
    public class Controller
    {
        float failHeight = -100f;
        Player.Base player;

        public Controller(Player.Base player, float failHeight)
        {
            this.player = player;
            this.failHeight = failHeight;
        }

        public bool IsFailed()
        {
            if (player.transform.position.y < failHeight)
                return true;
            return false;
        }
    }
}
