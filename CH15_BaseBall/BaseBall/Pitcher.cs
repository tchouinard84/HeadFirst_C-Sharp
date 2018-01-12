using System;
using System.Collections.ObjectModel;

namespace BaseBall
{
    public class Pitcher
    {
        public ObservableCollection<string> PitcherSays { get; set; }
        private int pitchNumber;
        private const string PREFIX = "Pitch #";

        public Pitcher(Ball ball)
        {
            ball.BallInPlay += Ball_BallInPlay;
            PitcherSays = new ObservableCollection<string>();
            pitchNumber = 0;
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber++;
            if (!(e is BallEventArgs)) { return; }

            var ballEventArgs = (BallEventArgs) e;
            PitcherSays.Add(DetermineText(ballEventArgs));
        }

        private string DetermineText(BallEventArgs ballEventArgs)
        {
            if (ballEventArgs.Distance >= 95) { return CoverFirstBase(); }
            if (ballEventArgs.Trajectory >= 60) { return CoverFirstBase(); }
            return CatchBall();
        }

        private string CoverFirstBase() => PREFIX + pitchNumber + ": I covered first base";
        private string CatchBall() => PREFIX + pitchNumber + ": I caught the ball";
    }
}
