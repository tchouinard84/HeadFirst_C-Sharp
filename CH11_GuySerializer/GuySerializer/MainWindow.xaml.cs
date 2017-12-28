using System.Windows;

namespace GuySerializer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GuyManager guyManager;

        public MainWindow()
        {
            InitializeComponent();

            guyManager = FindResource("guyManager") as GuyManager;
        }

        private void WriteJoe_OnClick(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Joe);
        }

        private void WriteBob_OnClick(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Bob);
        }

        private void WriteEd_OnClick(object sender, RoutedEventArgs e)
        {
            guyManager.WriteGuy(guyManager.Ed);
        }

        private void ReadNewGuy_OnClick(object sender, RoutedEventArgs e)
        {
            guyManager.ReadGuy();
        }
    }
}
