
namespace FlappyPlane.Web.Game.Models
{
    public class GameManager
    {
        private readonly int _gravity = 2;

        public event EventHandler? MainLoopCompleted;

        public BirdModel Bird { get; set; }
        public PipeModel Pipe { get; set; }
        public bool IsRunning { get; set; } = false;

        public GameManager()
        {
            Bird = new BirdModel();
            Pipe = new PipeModel();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while(IsRunning)
            {
                Bird.Fall(_gravity);
                Pipe.Move();
             
                if(Bird.DistanceFromGround <= 0)
                {
                    GameOver();
                }

                MainLoopCompleted?.Invoke(this, EventArgs.Empty);
                
                await Task.Delay(20);
            }
        }

        public void StartGame()
        {
            if (!IsRunning)
            {
                Bird = new BirdModel();
                MainLoop();
            }       
        }

        public void Jump()
        {
            if(IsRunning)
            {
                Bird.Jump();
            }
        }

        public void GameOver()
        {
            IsRunning = false;
        }
    }
}
