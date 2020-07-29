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
    public class BakRowSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is EDateType type)
            {
                if(object.Equals("RowSpan", parameter))
                {
                    switch(type)
                    {
                        case EDateType.Days:
                            return 1;
                        case EDateType.Month:
                        case EDateType.Year:
                            return 2;
                    }
                }
                else if (object.Equals("Row", parameter))
                {
                    switch(type)
                    {
                        case EDateType.Days:
                            return 2;
                        case EDateType.Month:
                        case EDateType.Year:
                            return 1;
                    }
                }
                else if(object.Equals("UniGricol", parameter))
                {
                    switch (type)
                    {
                        case EDateType.Days:
                            return 7;
                        case EDateType.Month:
                        case EDateType.Year:
                            return 4;
                    }
                }
            }
            return 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
