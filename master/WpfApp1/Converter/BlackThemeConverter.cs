using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using WpfApp1.ViewModel;

namespace WpfApp1.Converter
{
    public class BlackThemeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color c = (parameter as SolidColorBrush).Color;
            
            //c = (b as SolidColorBrush).Color;
            if (value.Equals(false))
            {
                if(c.R + c.G + c.B < 384)
                {
                    c = Color.FromRgb((byte)(255 - c.R), (byte)(255 - c.G), (byte)(255 - c.B));
                }
            }
            else if(value.Equals(true))
            {
                if (c.R + c.G + c.B > 384)
                {
                    c = Color.FromRgb((byte)(255 - c.R), (byte)(255 - c.G), (byte)(255 - c.B));
                }
            }
            
            return new SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
