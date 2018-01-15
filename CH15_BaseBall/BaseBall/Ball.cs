using System;

namespace BaseBall
{
    public class Ball
    {
        public event EventHandler BallInPlay;

        protected void OnBallInPlay(BallEventArgs e)
        {
            var ballInPlay = BallInPlay;
            if (ballInPlay == null) { return; }
            ballInPlay(this, e);
        }

        public Bat GetNewBat()
        {
            return new Bat(OnBallInPlay);
        }
    }
}
