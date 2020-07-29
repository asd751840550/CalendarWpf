using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp1.ViewModel.Calendar;

namespace WpfApp1.Converter.Calendar
{
    class StoryboardTargetNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EDateType type)
            {
                
                switch (type)
                {
                    case EDateType.Days:
                        return "lstboxDays";
                    case EDateType.Month:
                        return "gdMonths";
                    case EDateType.Year:
                        return "gdYears";
                }
                
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
