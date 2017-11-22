using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TestAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private int i;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += OnTimerTick;
            timer.Interval = TimeSpan.FromSeconds(.1);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            progress.Text = i++.ToString();
        }

        private async void OnClickCountButton(object sender, RoutedEventArgs e)
        {
            countButton.IsEnabled = false;
            timer.Start();
            if (useAwaitAsync.IsChecked == true) { await LongTaskAsync(); }
            else { LongTask(); }
            countButton.IsEnabled = true;
        }

        private void LongTask()
        {
            Thread.Sleep(5000);
            timer.Stop();
        }

        private async Task LongTaskAsync()
        {
            await Task.Delay(5000);
            timer.Stop();
        }

        private void OnClickColorButton(object sender, RoutedEventArgs e)
        {
            var colors = new byte[3];
            random.NextBytes(colors);
            windowContents.Background = new SolidColorBrush(Color.FromArgb(0xFF, colors[0], colors[1], colors[2]));
        }
    }
}
