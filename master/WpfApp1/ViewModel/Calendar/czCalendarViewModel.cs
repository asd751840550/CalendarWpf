using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp1.ViewModel;
namespace WpfApp1.ViewModel.Calendar
{
    public class czCalendarViewModel : BaseViewModel
    {
        private bool _isBlackTheme;
        private DateTime _showingDate;
        private DateTime _selectedDate;
        private EDateType _calendarType;
        //private int _year;
        //private int _month;
        //private int _day;
        private List<ItemType> _lstDays;
        private List<ItemType> _lstMonth;
        private List<ItemType> _lstYear;
        public czCalendarViewModel()
        {
            _isBlackTheme = false;
            _selectedDate = DateTime.Now;
            _calendarType = EDateType.Days;
            _lstDays = new List<ItemType>();
            _lstMonth = new List<ItemType>();
            _lstYear = new List<ItemType>();
        }

        public EDateType CalendarType
        {
            get => _calendarType;
            set
            {
                _calendarType = value;
                OnPropertyChanged();
            }
        }
        
        public List<ItemType> LstDays
        {
            get => _lstDays;
            set
            {
                _lstDays = value;
                OnPropertyChanged();
            }
        }

        public List<ItemType> LstMonth
        {
            get => _lstMonth;
            set
            {
                _lstMonth = value;
                OnPropertyChanged();
            }
        }

        public List<ItemType> LstYear
        {
            get => _lstYear;
            set
            {
                _lstYear = value;
                OnPropertyChanged();
            }
        }


        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                //this.Year = _selectedDate.Year;
                //this.Day = _selectedDate.Day;
                //this.Month = _selectedDate.Month;
                this.ShowingDate = _selectedDate;
            }
        }

        public DateTime ShowingDate
        {
            get => _showingDate;
            set
            {
                DateRefresh(_showingDate, value);
                
                _showingDate = value;
                OnPropertyChanged();
            }
        }

        public bool IsBlackTheme
        {
            get => _isBlackTheme;
            set
            {
                _isBlackTheme = value;
                OnPropertyChanged();
            }
        }

        //public int Year
        //{
        //    get => _year;
        //    private set
        //    {
        //        if (_year != value)
        //        {
        //            _year = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //public int Month
        //{
        //    get => _month;
        //    private set
        //    {
        //        if(_month != value)
        //        {
        //            _month = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //public int Day
        //{
        //    get => _day;
        //    private set
        //    {
        //        if(_day != value)
        //        {
        //            _day = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        private void DateRefresh(DateTime src, DateTime dst)
        {
            //Days
            if (dst.Month != src.Month)
            {
                List<ItemType> tmpdays = new List<ItemType>();
                int daycount = DateTime.DaysInMonth(dst.Year, dst.Month);
                DateTime firstDay = new DateTime(dst.Year, dst.Month, 1);
                DateTime lastDay = firstDay.AddDays(daycount - 1);
                ItemType tmpitem;
                for (int idx = (int)firstDay.DayOfWeek - 1; idx >= (int)DayOfWeek.Sunday; --idx)
                {
                    tmpitem = new ItemType() { CurDate = firstDay.AddDays(-(idx + 1)), BGColor = Color.FromRgb(133,133,133), TypeRemarks = "", DateType = EDateType.Days};                    
                    tmpdays.Add(tmpitem);
                }
                for(int idx = 0; idx < daycount + (DayOfWeek.Saturday - lastDay.DayOfWeek); ++idx)
                {
                    if (idx >= daycount)
                    {
                        tmpitem = new ItemType() { CurDate = firstDay.AddDays(idx), BGColor = Color.FromRgb(133, 133, 133), TypeRemarks = "", DateType = EDateType.Days };
                    }
                    else
                    {
                        tmpitem = new ItemType() { CurDate = firstDay.AddDays(idx), BGColor = Color.FromRgb(212, 212, 212), TypeRemarks = "Norqweqweqweqweqwmal", DateType = EDateType.Days };
                    }
                    tmpdays.Add(tmpitem);
                }
                this.LstDays = tmpdays;
            }
            //Month
            if(dst.Year != src.Year)
            {
                List<ItemType> tmpmonths = new List<ItemType>();
                DateTime month = new DateTime(dst.Year, 1, 1);
                ItemType tmpitem;
                for (int idx = 0; idx < 12; ++idx)
                {
                    tmpitem = new ItemType() { CurDate = month.AddMonths(idx), BGColor = Color.FromRgb(212, 212, 212), TypeRemarks = "", DateType = EDateType.Month };
                    tmpmonths.Add(tmpitem);
                }
                this.LstMonth = tmpmonths;
            }
            //Year
            DateTime tmpyear;
            try
            {
                tmpyear = src.AddYears(-(src.Year % 10));
            }
            catch(Exception ex)
            {
                tmpyear = src;
            }
             
            if(dst.Year < tmpyear.Year || dst.Year> tmpyear.AddYears(9).Year)
            {
                List<ItemType> tmpyears = new List<ItemType>();
                ItemType tmpitem;
                tmpyear = dst.AddYears(-(dst.Year % 10));
                for (int idx = 0; idx < 12; ++idx)
                {
                    if(idx < 10)
                    {
                        tmpitem = new ItemType() { CurDate = tmpyear .AddYears(idx), BGColor = Color.FromRgb(212, 212, 212), TypeRemarks = "", DateType = EDateType.Year };
                    }
                    else
                    {
                        tmpitem = new ItemType() { CurDate = tmpyear.AddYears(idx), BGColor = Color.FromRgb(133, 133, 133), TypeRemarks = "", DateType = EDateType.Year };
                    }
                    tmpyears.Add(tmpitem);
                }
                this.LstYear = tmpyears;
            }
        }
    }
}
