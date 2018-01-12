using System;

namespace BaseBall
{
    public class BallEventArgs : EventArgs
    {
        public int Trajectory { get; private set; }
        public int Distance { get; private set; }

        public BallEventArgs(int trajectory, int distance)
        {
            Trajectory = trajectory;
            Distance = distance;
        }
    }
}
