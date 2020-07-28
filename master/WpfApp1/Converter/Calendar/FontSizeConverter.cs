﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converter.Calendar
{
    public class czFontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((double)value == 0)
            {
                return 20;
            }
            if(object.Equals(parameter, "Week"))
            {
                return (double)value / 4 * 2;
            }
            else if (object.Equals(parameter, "Day"))
            {
                return (double)value / 6 * 4;
            }
            return (double)value / 4 * 3;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
