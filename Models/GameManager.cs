using System.ComponentModel;

namespace FlappyPlane.Web.Game.Models
{
    public class GameManager : INotifyPropertyChanged
    {
        private readonly int _gravity = 2;

        public event PropertyChangedEventHandler? PropertyChanged;

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bird)));

                Pipe.Move();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pipe)));


                if(Bird.DistanceFromGround <= 0)
                {
                    GameOver();
                }
                
                
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

        public void GameOver()
        {
            IsRunning = false;
        }
    }
}
