using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace GuySerializer
{
    public partial class MainWindow : Window
    {
        private const string Filter  = "XML Files (.xml)|*.xml";
        private const string DefaultExt = ".xml";
        private readonly GuyManager _guyManager;

        public MainWindow()
        {
            InitializeComponent();

            _guyManager = FindResource("guyManager") as GuyManager;
        }

        private void WriteJoe_OnClick(object sender, RoutedEventArgs e)
        {
            SaveGuy(_guyManager.Joe);
        }

        private void WriteBob_OnClick(object sender, RoutedEventArgs e)
        {
            SaveGuy(_guyManager.Bob);
        }

        private void WriteEd_OnClick(object sender, RoutedEventArgs e)
        {
            SaveGuy(_guyManager.Ed);
        }

        private void SaveGuy(Guy guy)
        {
            var saveDialog = new SaveFileDialog
            {
                FileName = guy.Name,
                DefaultExt = DefaultExt,
                Filter = Filter
            };

            if (saveDialog.ShowDialog() != true) { return; }
            _guyManager.WriteGuy(guy, saveDialog.FileName);
        }

        private void ReadNewGuy_OnClick(object sender, RoutedEventArgs e)
        {
            var guyFile = string.IsNullOrEmpty(_guyManager.GuyFile) ? "" : _guyManager.GuyFile;

            var openDialog = new OpenFileDialog
            {
                FileName = Path.GetFileName(guyFile),
                DefaultExt = DefaultExt,
                Filter = Filter
            };

            if (openDialog.ShowDialog() != true) { return; }
            _guyManager.ReadGuy(openDialog.FileName);
        }
    }
}
