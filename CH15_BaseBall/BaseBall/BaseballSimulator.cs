using System.Collections.ObjectModel;

namespace BaseBall
{
    public class BaseballSimulator
    {
        private Ball ball = new Ball();
        private Pitcher pitcher;
        private Fan fan;

        public ObservableCollection<string> FanSays => fan.FanSays;
        public ObservableCollection<string> PitcherSays => pitcher.PitcherSays;

        public int Trajectory { get; set; }
        public int Distance { get; set; }

        public BaseballSimulator()
        {
            pitcher = new Pitcher(ball);
            fan = new Fan(ball);
        }

        public void PlayBall()
        {
            var ballEventArgs = new BallEventArgs(Trajectory, Distance);
            ball.OnBallInPlay(ballEventArgs);
        }
    }
}
