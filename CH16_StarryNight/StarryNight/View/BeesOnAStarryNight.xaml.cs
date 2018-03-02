using StarryNight.ViewModel;
using System.Windows;

namespace StarryNight.View
{
    /// <summary>
    /// Interaction logic for BeesOnAStarryNight.xaml
    /// </summary>
    public partial class BeesOnAStarryNight : Window
    {
        private readonly BeeStarViewModel _viewModel;

        public BeesOnAStarryNight()
        {
            InitializeComponent();

            _viewModel = FindResource("viewModel") as BeeStarViewModel;
        }

        private void SizeChangedHandler(object sender, SizeChangedEventArgs e)
        {
            _viewModel.PlayAreaSize = new Size(e.NewSize.Width, e.NewSize.Height);
        }
    }
}
