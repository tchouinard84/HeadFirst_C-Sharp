using Stopwatch.Model;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Stopwatch.ViewModel
{
    public class StopwatchViewModel : INotifyPropertyChanged
    {
        private static readonly StopwatchModel _stopwatchModel = new StopwatchModel();
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private int _lastHours;
        private int _lastMinutes;
        private decimal _lastSeconds;
        private bool _lastRunning;

        private int _lastLapHours;
        private int _lastLapMinutes;
        private decimal _lastLapSeconds;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Hours => _stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Hours : 0;
        public int Minutes => _stopwatchModel.Elapsed.HasValue ? _stopwatchModel.Elapsed.Value.Minutes : 0;
        public decimal Seconds => _stopwatchModel.Elapsed.HasValue
            ? _stopwatchModel.Elapsed.Value.Seconds + _stopwatchModel.Elapsed.Value.Milliseconds * .001M
            : 0.0M;

        public int LapHours => _stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Hours : 0;
        public int LapMinutes => _stopwatchModel.LapTime.HasValue ? _stopwatchModel.LapTime.Value.Minutes : 0;
        public decimal LapSeconds => _stopwatchModel.LapTime.HasValue
            ? _stopwatchModel.LapTime.Value.Seconds + _stopwatchModel.LapTime.Value.Milliseconds * .001M
            : 0.0M;

        public bool Running => _stopwatchModel.Running;

        public StopwatchViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += TimerTick;
            _timer.Start();

            _stopwatchModel.LapTimeUpdated += LapTimeUpdatedEventHandler;
        }

        public void Start()
        {
            _stopwatchModel.Start();
        }

        public void Stop()
        {
            _stopwatchModel.Stop();
        }

        public void Lap()
        {
            _stopwatchModel.Lap();
        }

        public void Reset()
        {
            var running = Running;
            _stopwatchModel.Reset();
            if (running) { _stopwatchModel.Start(); }
            OnPropertyChanged("LapHours");
            OnPropertyChanged("LapMinutes");
            OnPropertyChanged("LapSeconds");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_lastRunning != Running) { FirePropertyChanged(Running, ref _lastRunning, "Running"); }
            if (_lastHours != Hours)     { FirePropertyChanged(Hours, ref _lastHours, "Hours"); }
            if (_lastMinutes != Minutes) { FirePropertyChanged(Minutes, ref _lastMinutes, "Minutes"); }
            if (_lastSeconds != Seconds) { FirePropertyChanged(Seconds, ref _lastSeconds, "Seconds"); }
        }

        private void LapTimeUpdatedEventHandler(object sender, LapEventArgs e)
        {
            if (_lastLapHours != LapHours) { FirePropertyChanged(LapHours, ref _lastLapHours, "LapHours"); }
            if (_lastLapMinutes != LapMinutes) { FirePropertyChanged(LapMinutes, ref _lastLapMinutes, "LapMinutes"); }
            if (_lastLapSeconds != LapSeconds) { FirePropertyChanged(LapSeconds, ref _lastLapSeconds, "LapSeconds"); }
        }

        private void FirePropertyChanged<T>(T property, ref T previous, string propertyName)
        {
            previous = property;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
