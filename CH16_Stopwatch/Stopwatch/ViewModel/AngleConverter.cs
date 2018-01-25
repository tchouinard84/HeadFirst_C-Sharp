using System;
using System.Globalization;
using System.Windows.Data;

namespace Stopwatch.ViewModel
{
    public class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return 0; }
            if (!double.TryParse(value.ToString(), out var parsedValue)) { return 0; }
            if (parameter == null) { return 0; }

            switch (parameter.ToString())
            {
                case "Hours":
                    return parsedValue * 30;
                case "Minutes":
                case "Seconds":
                    return parsedValue * 6;
                default:
                    return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
