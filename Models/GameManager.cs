namespace FlappyPlane.Web.Game.Models
{
    public class GameManager
    {
        public BirdModel Bird { get; set; }

        public GameManager()
        {
            Bird = new BirdModel();
        }
    }
}
