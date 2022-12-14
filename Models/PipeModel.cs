namespace FlappyPlane.Web.Game.Models
{
    public class PipeModel
    {
        public int DistanceFromLeft { get; private set; } = 500;
        public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
        public int Speed { get; set; } = 2;
        
        //между верхиними и нижними трубами
        public int Gap { get; set; } = 130;

        public int GapBottom => DistanceFromBottom + 300;
        public int GapTop => GapBottom + Gap;

        public bool OffScreen()
        {
            return DistanceFromLeft <= -60;
        }

        public void Move()
        {
            DistanceFromLeft -= Speed;
        }

        public bool isCentered()
        {
            bool hasEnteredCenter = DistanceFromLeft <= (500 / 2) + (60 / 2);
            bool hasExitedCenter = DistanceFromLeft <= (500 / 2) - (60 / 2) - 60;

            return hasEnteredCenter && !hasExitedCenter;
        }
    }
}
