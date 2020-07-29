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
    public class ListBoxItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ItemType item)
            {
                if (parameter.Equals("Date"))
                {
                    switch (item.DateType)
                    {
                        case EDateType.Days:
                            return item.CurDate.ToString("dd");
                        case EDateType.Month:
                            return item.CurDate.ToString("MMM", CultureInfo.CreateSpecificCulture("en-US"));
                        case EDateType.Year:
                            return item.CurDate.Year.ToString();
                    }
                }
                else if(parameter.Equals("Remarks"))
                {
                    return item.TypeRemarks;
                }
            }
            
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return (double)value + 5;
            throw new NotImplementedException();
        }
    }
}
