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
    public class ListBoxItemOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ItemType item)
            {
                return (double)item.Opacity;
            }
            
            return (double)1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
