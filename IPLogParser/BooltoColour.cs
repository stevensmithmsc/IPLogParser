using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace IPLogParser
{
    public class BooltoColour : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color returnValue = Colors.White;
            if (value is bool)
            {
                returnValue = (bool)value ? Colors.Red : Colors.Black;
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool returnValue = default(bool);
            if (value is Color)
            {
                if ((Color)value == Colors.Red) { returnValue = true; }
                else if ((Color)value == Colors.Black) { returnValue = false; }
            }
            return returnValue;

        }
    }
}
