using System.Windows.Media.Imaging;

namespace JimmysComics.DataModel
{
    public class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public int Year { get; set; }
        public string CoverPrice { get; set; }
        public string Synopsis { get; set; }
        public string MainVillain { get; set; }
        public BitmapImage Cover { get; set; }
    }
}