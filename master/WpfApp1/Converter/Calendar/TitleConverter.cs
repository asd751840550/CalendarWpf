using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WpfApp1.czUserControl.Logic;
using WpfApp1.ViewModel.Calendar;

namespace WpfApp1.Converter.Calendar
{
    public class TitleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string content = string.Empty;
            if(values[0] is EDateType type && values[1] is DateTime curdate)
            {
                
                switch (type)
                {
                    case EDateType.Days:
                        content = string.Format($"{curdate.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"))}  {curdate.Year}");
                        break;
                    case EDateType.Month:
                        content = curdate.Year.ToString();
                        break;
                    case EDateType.Year:
                        DateTime tmpdate = curdate.addYearsExtend(-curdate.Year % 10);
                        content = string.Format($"{tmpdate.Year} - {tmpdate.addYearsExtend(9).Year}");
                        break;
                }
            }
            return content;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
