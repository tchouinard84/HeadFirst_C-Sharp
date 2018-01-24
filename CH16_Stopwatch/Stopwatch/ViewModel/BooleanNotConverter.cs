using System;
using System.Globalization;
using System.Windows.Data;

namespace Stopwatch.ViewModel
{
    public class BooleanNotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) { return false; }
            if ((bool) value == true) { return false; }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
