using JimmysComics.DataModel;
using System.Windows;
using System.Windows.Controls;

namespace JimmysComics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ComicQueryManager _comicQueryManager;

        public MainWindow()
        {
            InitializeComponent();

            _comicQueryManager = FindResource("comicQueryManager") as ComicQueryManager;
            _comicQueryManager.UpdateQueryResults(_comicQueryManager.AvailableQueries[0]);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1) { return; }
            if (!(e.AddedItems[0] is ComicQuery)) { return; }

            _comicQueryManager.CurrentQueryResults.Clear();
            _comicQueryManager.UpdateQueryResults(e.AddedItems[0] as ComicQuery);
        }
    }
}
