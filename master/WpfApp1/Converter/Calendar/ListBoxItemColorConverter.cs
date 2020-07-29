using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using WpfApp1.ViewModel.Calendar;

namespace WpfApp1.Converter.Calendar
{
    public class ListBoxItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ItemType item)
            {
                return new SolidColorBrush(item.BGColor);
            }
            else if(value is SolidColorBrush sco)
            {
                if(object.Equals("Selected", parameter))
                {
                    return new SolidColorBrush(Color.FromRgb((byte)(255 - sco.Color.R), (byte)(255 - sco.Color.G), (byte)(255 - sco.Color.B)));
                }
                else if(object.Equals("Over", parameter))
                {
                    return new SolidColorBrush(Color.Multiply(Color.FromRgb((byte)(255 - sco.Color.R), (byte)(255 - sco.Color.G), (byte)(255 - sco.Color.B)), (float)0.6));
                }
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
