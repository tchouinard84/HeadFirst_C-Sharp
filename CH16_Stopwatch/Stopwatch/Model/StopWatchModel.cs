using System;

namespace Stopwatch.Model
{
    public class StopwatchModel
    {
        private DateTime? _started;
        private TimeSpan? _previousElapsedTime;

        public event EventHandler<LapEventArgs> LapTimeUpdated; 

        public bool Running => _started.HasValue;

        public TimeSpan? LapTime { get; private set; }

        public TimeSpan? Elapsed
        {
            get
            {
                if (!_started.HasValue) { return _previousElapsedTime; }
                if (!_previousElapsedTime.HasValue) { return CalculateTimeElapsedSinceStarted(); }
                return CalculateTimeElapsedSinceStarted() + _previousElapsedTime;
            }
        }

        public StopwatchModel()
        {
            Reset();
        }

        public void Start()
        {
            _started = DateTime.Now;
            if (_previousElapsedTime.HasValue) { return; }
            _previousElapsedTime = new TimeSpan(0);
        }

        public void Stop()
        {
            if (!_started.HasValue) { return; }
            _previousElapsedTime += DateTime.Now - _started.Value;
            _started = null;
        }

        public void Reset()
        {
            _previousElapsedTime = null;
            _started = null;
            LapTime = null;
        }

        public void Lap()
        {
            LapTime = Elapsed;
            OnLapTimeUpdated(LapTime);
        }

        private void OnLapTimeUpdated(TimeSpan? lapTime)
        {
            var lapTimeUpdated = LapTimeUpdated;
            if (lapTimeUpdated == null) { return; }
            lapTimeUpdated(this, new LapEventArgs(lapTime));
        }

        private TimeSpan CalculateTimeElapsedSinceStarted()
        {
            return DateTime.Now - _started.Value;
        }
    }
}
