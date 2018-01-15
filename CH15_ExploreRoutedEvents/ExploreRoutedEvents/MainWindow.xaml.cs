using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExploreRoutedEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> outputItems = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            output.ItemsSource = outputItems;
        }

        private void StackPanel_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource) { outputItems.Clear(); }
            outputItems.Add("The panel was pressed");
        }

        private void Border_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            OnMouseDown(sender, e, "border", borderSetsHandled);
        }

        private void Grid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            OnMouseDown(sender, e, "grid", gridSetsHandled);
        }

        private void Ellipse_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            OnMouseDown(sender, e, "ellipse", ellipseSetsHandled);
        }

        private void Rectangle_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            OnMouseDown(sender, e, "rectangle", rectangleSetsHandled);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e, string item, CheckBox checkBoxControl)
        {
            if (sender == e.OriginalSource) { outputItems.Clear(); }
            outputItems.Add($"The {item} was pressed");
            if (checkBoxControl.IsChecked == true) { e.Handled = true; }
        }

        private void OnClick_UpdateHitTest(object sender, RoutedEventArgs e)
        {
            grayRectangle.IsHitTestVisible = (bool)newHitTestVisibleValue.IsChecked;
        }
    }
}
