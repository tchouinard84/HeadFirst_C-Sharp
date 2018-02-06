using Stopwatch.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Stopwatch.View
{
    /// <summary>
    /// Interaction logic for AnalogStopwatch.xaml
    /// </summary>
    public partial class AnalogStopwatch : UserControl
    {
        private readonly StopwatchViewModel _viewModel;

        public AnalogStopwatch()
        {
            InitializeComponent();

            _viewModel = FindResource("ViewModel") as StopwatchViewModel;
            AddMarkings();
        }

        private void AddMarkings()
        {
            AddMarkings(.5, 10, -220, 1.2);
            AddMarkings(1, 15, -215, 6);
            AddMarkings(3, 25, -210, 30);
        }

        private void AddMarkings(double width, double height, double offset, double angleBetween)
        {
            for (var i = 0.0; i < 360.0; i += angleBetween)
            {
                var rectangle = new Rectangle();
                rectangle.Width = width;
                rectangle.Height = height;
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);

                var transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform { Y = offset });
                transforms.Children.Add(new RotateTransform { Angle = i });
                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Stop();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Reset();
        }

        private void LapButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Lap();
        }
    }
}
