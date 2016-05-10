using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace IPLogParser
{
    public class BooltoColour : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            Color returnValue = Colors.Black;
            if (value is bool)
            {
                returnValue = (bool)value ? Colors.Red : Colors.White;
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            bool returnValue = default(bool);
            if (value is Color)
            {
                if ((Color)value == Colors.Red) { returnValue = true; }
                else if ((Color)value == Colors.White) { returnValue = false; }
            }
            return returnValue;

        }
    }
}
