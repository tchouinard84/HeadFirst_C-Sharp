using System;

namespace Stopwatch.Model
{
    public class LapEventArgs : EventArgs
    {
        public TimeSpan? LapTime { get; private set; }

        public LapEventArgs(TimeSpan? lapTime)
        {
            LapTime = lapTime;
        }
    }
}
