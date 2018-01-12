using System;
using System.Collections.ObjectModel;

namespace BaseBall
{
    public class Fan
    {
        public ObservableCollection<string> FanSays { get; set; }
        private int pitchNumber;
        private const string PREFIX = "Pitch #";

        public Fan(Ball ball)
        {
            ball.BallInPlay += Ball_BallInPlay;
            FanSays = new ObservableCollection<string>();
            pitchNumber = 0;
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber++;
            if (!(e is BallEventArgs)) { return; }

            var ballEventArgs = (BallEventArgs)e;
            FanSays.Add(DetermineText(ballEventArgs));
        }

        private string DetermineText(BallEventArgs ballEventArgs)
        {
            if (ballEventArgs.Distance <= 400) { return ScreamAndYell(); }
            if (ballEventArgs.Trajectory <= 30) { return ScreamAndYell(); }
            return TryToCatchBall();
        }

        private string ScreamAndYell() => PREFIX + pitchNumber + ": Woo-hoo! Yeah!";
        private string TryToCatchBall() => PREFIX + pitchNumber + ": Home run! I'm going for the ball!";
    }
}
