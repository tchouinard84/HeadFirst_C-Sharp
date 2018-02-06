using Stopwatch.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            AddHands();
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
                var rectangle = Rectangle(width, height, new SolidColorBrush(Colors.Black));

                var transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform { Y = offset });
                transforms.Children.Add(new RotateTransform { Angle = i });
                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }
        }

        private void AddHands()
        {
            AddHand(1.5, 230, -100, new SolidColorBrush(Colors.Black), "Seconds", "Seconds");
            AddHand(3, 175, -75, new SolidColorBrush(Colors.Black), "Minutes", "Minutes");
            AddHand(.75, 230, -100, new SolidColorBrush(Colors.Yellow), "LapSeconds", "Seconds");
            AddHand(1.5, 175, -75, new SolidColorBrush(Colors.Yellow), "LapMinutes", "Minutes");
        }

        private void AddHand(double width, double height, double offset, Brush color, string property, string converterParameter)
        {
            var transforms = new TransformGroup();
            transforms.Children.Add(new TranslateTransform { Y = offset });
            transforms.Children.Add(RotateTransform(property, converterParameter));
            baseGrid.Children.Add(Rectangle(width, height, color, transforms));
        }

        private static Rectangle Rectangle(double width, double height, Brush color, Transform transforms = null)
        {
            return new Rectangle
            {
                Width = width,
                Height = height,
                Fill = color,
                RenderTransformOrigin = new Point(0.5, 0.5),
                RenderTransform = transforms
            };
        }

        private RotateTransform RotateTransform(string property, string converterParameter)
        {
            var rotateTransform = new RotateTransform();
            BindingOperations.SetBinding(rotateTransform, System.Windows.Media.RotateTransform.AngleProperty,
                BindingFor(property, converterParameter));
            return rotateTransform;
        }

        private Binding BindingFor(string property, string converterParameter)
        {
            return new Binding()
            {
                Source = _viewModel,
                Path = new PropertyPath(property),
                Converter = new AngleConverter(),
                ConverterParameter = converterParameter
            };
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
