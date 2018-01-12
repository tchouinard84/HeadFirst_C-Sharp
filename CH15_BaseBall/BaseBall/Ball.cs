﻿using System;

namespace BaseBall
{
    public class Ball
    {
        public event EventHandler BallInPlay;

        public void OnBallInPlay(BallEventArgs e)
        {
            var ballInPlay = BallInPlay;
            if (ballInPlay == null) { return; }
            ballInPlay(this, e);
        }
    }
}
