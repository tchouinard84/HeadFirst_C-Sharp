﻿using Stopwatch.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Stopwatch.View
{
    /// <summary>
    /// Interaction logic for BasicStopwatch.xaml
    /// </summary>
    public partial class BasicStopwatch : UserControl
    {
        private readonly StopwatchViewModel viewModel;

        public BasicStopwatch()
        {
            InitializeComponent();

            viewModel = FindResource("ViewModel") as StopwatchViewModel;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Stop();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Reset();
        }

        private void LapButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Lap();
        }
    }
}
