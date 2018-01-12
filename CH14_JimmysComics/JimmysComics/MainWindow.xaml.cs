using JimmysComics.DataModel;
using System.Linq;
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

        private void OnSelectQuery(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1) { return; }
            if (!(e.AddedItems[0] is ComicQuery)) { return; }

            _comicQueryManager.CurrentQueryResults.Clear();
            _comicQueryManager.UpdateQueryResults((ComicQuery) e.AddedItems[0]);
        }

        private void OnSelectCurrentQuery(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1) { return; }

            var item = e.AddedItems[0];
            var properties = item.GetType().GetProperties();
            if (!properties.Any(x => x.Name == "Comic")) { return; }

            var comic = (item as dynamic).Comic as Comic;

            CoverImage.Source = comic.Cover;
            ViewName.Text = comic.Name;
            ViewIssue.Text = comic.Issue.ToString();
            ViewYear.Text = comic.Year.ToString();
            ViewCoverPrice.Text = comic.CoverPrice;
            ViewMainVillian.Text = comic.MainVillain;
            ViewSynopsis.Text = comic.Synopsis;

        }
    }
}
