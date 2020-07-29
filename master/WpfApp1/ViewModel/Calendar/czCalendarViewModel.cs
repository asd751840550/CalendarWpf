using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp1.czUserControl.Logic;
using WpfApp1.ViewModel;
namespace WpfApp1.ViewModel.Calendar
{
    public class czCalendarViewModel : BaseViewModel
    {
        private bool _isBlackTheme;           //黑色主题
        private DateTime _showingDate;        //当前正在显示的日期
        private DateTime _selectedDate;       //当前选择的日期
        private EDateType _calendarType;      //当前日历显示状态
        private List<ItemType> _lstDays;      //当前月的天数，用于显示
        private List<ItemType> _lstMonth;     //当前年的月数，用于显示
        private List<ItemType> _lstYear;      //当前总览年份，用于显示
        private List<ItemType> _lstBakDate;   //备份showingDate，用于滚动
        public czCalendarViewModel()
        {
            _isBlackTheme = false;
            _selectedDate = DateTime.Now;
            _calendarType = EDateType.Days;
            _lstDays = new List<ItemType>();
            _lstMonth = new List<ItemType>();
            _lstYear = new List<ItemType>();
        }

        /// <summary>
        /// 当前日历显示状态，/年/月/日
        /// </summary>
        public EDateType CalendarType
        {
            get => _calendarType;
            set
            {
                _calendarType = value;
                BackupDate();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前月的天数，用于显示
        /// </summary>
        public List<ItemType> LstDays
        {
            get => _lstDays;
            set
            {
                _lstDays = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前年的月数，用于显示
        /// </summary>
        public List<ItemType> LstMonth
        {
            get => _lstMonth;
            set
            {
                _lstMonth = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前总览年份，用于显示
        /// </summary>
        public List<ItemType> LstYear
        {
            get => _lstYear;
            set
            {
                _lstYear = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 备份showingDate，用于滚动
        /// </summary>
        public List<ItemType> LstBakDate
        {
            get => _lstBakDate;
            set
            {
                _lstBakDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前选择的日期
        /// </summary>
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                this.ShowingDate = _selectedDate;
            }
        }

        /// <summary>
        /// 当前正在显示的日期
        /// </summary>
        public DateTime ShowingDate
        {
            get => _showingDate;
            set
            {
                BackupDate();
                DateRefresh(_showingDate, value);
                _showingDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 黑色主题
        /// </summary>
        public bool IsBlackTheme
        {
            get => _isBlackTheme;
            set
            {
                _isBlackTheme = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 备份日期
        /// </summary>
        private void BackupDate()
        {
            switch(_calendarType)
            {
                case EDateType.Days:
                    LstBakDate = _lstDays;
                    break;
                case EDateType.Month:
                    LstBakDate = _lstMonth;
                    break;
                case EDateType.Year:
                    LstBakDate = _lstYear;
                    break;
            }
        }

        /// <summary>
        /// 刷新日期
        /// </summary>
        /// <param name="src">原始日期</param>
        /// <param name="dst">目的日期</param>
        private void DateRefresh(DateTime src, DateTime dst)
        {
            //Days
            if (dst.Month != src.Month)
            {
                List<ItemType> tmpdays = new List<ItemType>();
                int daycount = DateTime.DaysInMonth(dst.Year, dst.Month);
                DateTime firstDay = new DateTime(dst.Year, dst.Month, 1);
                DateTime lastDay = firstDay.addDaysExtend(daycount - 1);
                ItemType tmpitem;
                for (int idx = (int)firstDay.DayOfWeek - 1; idx >= (int)DayOfWeek.Sunday; --idx)
                {
                    tmpitem = new ItemType() { CurDate = firstDay.addDaysExtend(-(idx + 1)), BGColor = Color.FromRgb(133,133,133), TypeRemarks = "", DateType = EDateType.Days, Opacity = 0.5 };                    
                    tmpdays.Add(tmpitem);
                }
                for(int idx = 0; idx < daycount + (DayOfWeek.Saturday - lastDay.DayOfWeek); ++idx)
                {
                    if (idx >= daycount)
                    {
                        tmpitem = new ItemType() { CurDate = firstDay.addDaysExtend(idx), BGColor = Color.FromRgb(133, 133, 133), TypeRemarks = "", DateType = EDateType.Days, Opacity = 0.5 };
                    }
                    else
                    {
                        tmpitem = new ItemType() { CurDate = firstDay.addDaysExtend(idx), BGColor = Color.FromRgb(212, 212, 212), TypeRemarks = "Norqweqweqweqweqwmal", DateType = EDateType.Days };
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
                    tmpitem = new ItemType() { CurDate = month.addMonthsExtend(idx), BGColor = Color.FromRgb(212, 212, 212), TypeRemarks = "", DateType = EDateType.Month };
                    tmpmonths.Add(tmpitem);
                }
                this.LstMonth = tmpmonths;
            }
            //Year
            DateTime tmpyear = src.addYearsExtend(-(src.Year % 10));

            if(dst.Year < tmpyear.Year || dst.Year> tmpyear.addYearsExtend(9).Year)
            {
                List<ItemType> tmpyears = new List<ItemType>();
                ItemType tmpitem;
                tmpyear = dst.addYearsExtend(-(dst.Year % 10));
                for (int idx = 0; idx < 12; ++idx)
                {
                    if(idx < 10)
                    {
                        tmpitem = new ItemType() { CurDate = tmpyear .addYearsExtend(idx), BGColor = Color.FromRgb(212, 212, 212), TypeRemarks = "", DateType = EDateType.Year};
                    }
                    else
                    {
                        tmpitem = new ItemType() { CurDate = tmpyear.addYearsExtend(idx), BGColor = Color.FromRgb(133, 133, 133), TypeRemarks = "", DateType = EDateType.Year, Opacity = 0.5 };
                    }
                    tmpyears.Add(tmpitem);
                }
                this.LstYear = tmpyears;
            }
        }
    }
}
