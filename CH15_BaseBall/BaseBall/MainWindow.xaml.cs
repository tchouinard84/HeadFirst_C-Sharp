using System.Windows;

namespace BaseBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BaseballSimulator _simulator;

        public MainWindow()
        {
            InitializeComponent();

            _simulator = FindResource("BaseballSimulator") as BaseballSimulator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _simulator.PlayBall();
        }
    }
}
