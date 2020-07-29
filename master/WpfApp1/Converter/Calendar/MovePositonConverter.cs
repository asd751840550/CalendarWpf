using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converter.Calendar
{
    public class MovePositonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            if(object.Equals(parameter, "Right") || object.Equals(parameter, "BakLeft"))
            {
                return (double)((double)value);
            }
            return -(double)((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
