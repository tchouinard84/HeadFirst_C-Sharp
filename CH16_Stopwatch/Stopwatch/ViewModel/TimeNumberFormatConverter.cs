using System;
using System.Globalization;
using System.Windows.Data;

namespace Stopwatch.ViewModel
{
    public class TimeNumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal) { return ((decimal) value).ToString("00.00"); }
            if (!(value is int)) { return value; }
            if (parameter == null) { return ((int) value).ToString("d1"); }
            return ((int) value).ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
