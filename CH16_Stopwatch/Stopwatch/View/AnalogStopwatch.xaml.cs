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
            for (var i = 0.0; i < 360.0; i += 1.2)
            {
                var rectangle = new Rectangle
                {
                    Width = .5,
                    Height = 10,
                    Fill = new SolidColorBrush(Colors.Black),
                    RenderTransformOrigin = new Point(0.5, 0.5)
                };

                var transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform { Y = -220 });
                transforms.Children.Add(new RotateTransform { Angle = i });
                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }

            for (var i = 0; i < 360; i += 6)
            {
                var rectangle = new Rectangle();
                rectangle.Width = 1;
                rectangle.Height = 15;
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);

                var transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform { Y = -215 });
                transforms.Children.Add(new RotateTransform { Angle = i });
                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }

            for (var i = 0; i < 360; i+=30)
            {
                var rectangle = new Rectangle();
                rectangle.Width = 3;
                rectangle.Height = 25;
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);

                var transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform { Y = -210 });
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
