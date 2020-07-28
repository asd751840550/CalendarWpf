using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.Calendar;
using WpfApp1.PubFunc;
using WpfApp1.Converter.Calendar;
using WpfApp1.Converter;
using WpfApp1.Animation;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using WpfApp1.czUserControl.Logic;

namespace WpfApp1
{
    /// <summary>
    /// czCalendar.xaml 的交互逻辑
    /// </summary>
    public partial class czCalendar : UserControl
    {
        private czCalendarViewModel _vmcalendar;
        
        public czCalendar()
        {
            InitializeComponent();
            _vmcalendar = new czCalendarViewModel();
            DataContext = _vmcalendar;
            _vmcalendar.CalendarType = EDateType.Days;
            _vmcalendar.SelectedDate = DateTime.Now;
        }

        public czCalendarViewModel VMCalendar
        {
            get => _vmcalendar;
        }

        private void CurDateText_Click(object sender, RoutedEventArgs e)
        {
            //_vmcalendar.IsBlackTheme = !_vmcalendar.IsBlackTheme;
            if(_vmcalendar.CalendarType < EDateType.Year)
            {
                _vmcalendar.CalendarType++;
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            czCalendarLogic.AddBGAnimation(pnlMain, _vmcalendar, "IsBlackTheme", Brushes.White.Color);
            czPubFunc.SetControlBinding(CurDateText, TextBlock.ForegroundProperty, _vmcalendar, "IsBlackTheme", new WhiteThemeConverter(), CurDateText.Foreground);
            czPubFunc.SetControlBinding(Leftbtn, TextBlock.ForegroundProperty, _vmcalendar, "IsBlackTheme", new WhiteThemeConverter(), Leftbtn.Foreground);
            czPubFunc.SetControlBinding(Rightbtn, TextBlock.ForegroundProperty, _vmcalendar, "IsBlackTheme", new WhiteThemeConverter(), Rightbtn.Foreground);
            for (int idx = 0; idx < 7; ++idx)
            {
                Border border = new Border() { Margin = new Thickness(1, 1, 1, 1) };
                TextBlock textBlock = new TextBlock { TextAlignment = TextAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Background = null };
                border.Child = textBlock;
                gdWeek.Children.Add(border);
                border.SetValue(Grid.ColumnProperty, idx);
                border.Background = new SolidColorBrush(Color.FromRgb(180, 180, 180));
                czCalendarLogic.AddBGAnimation(border, _vmcalendar, "IsBlackTheme", Color.FromRgb(180, 180, 180));                                    
                czPubFunc.SetControlBinding(textBlock, TextBlock.ForegroundProperty, _vmcalendar, "IsBlackTheme", new WhiteThemeConverter(), textBlock.Foreground);
                czPubFunc.SetControlBinding(textBlock, TextBlock.FontSizeProperty, border, "ActualHeight", new czFontSizeConverter(), "Week");
                textBlock.Text = ((EDayWeek)idx).ToString();
            }
            this.lstboxYear.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(ListBox_MouseDown), true);
            this.lstboxMonth.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(ListBox_MouseDown), true);
        }

        private void ListBox_MouseDown(object sender, RoutedEventArgs e)
        {
            
            if (_vmcalendar.CalendarType > EDateType.Days)
            {
                var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
                if (item != null)
                {
                    _vmcalendar.ShowingDate = (item.Content as ItemType).CurDate;
                    _vmcalendar.CalendarType--;
                }
            }
        }

        private void Leftbtn_Click(object sender, RoutedEventArgs e)
        {
            switch(_vmcalendar.CalendarType)
            {
                case EDateType.Days:
                    _vmcalendar.ShowingDate = _vmcalendar.ShowingDate.AddMonths(-1);
                    break;
                case EDateType.Month:
                    _vmcalendar.ShowingDate = _vmcalendar.ShowingDate.AddYears(-1);
                    break;
                case EDateType.Year:
                    _vmcalendar.ShowingDate = _vmcalendar.ShowingDate.AddYears(-10);
                    break;
            }
        }

        private void Rightbtn_Click(object sender, RoutedEventArgs e)
        {
            switch (_vmcalendar.CalendarType)
            {
                case EDateType.Days:
                    _vmcalendar.ShowingDate = _vmcalendar.ShowingDate.AddMonths(1);
                    break;
                case EDateType.Month:
                    _vmcalendar.ShowingDate = _vmcalendar.ShowingDate.AddYears(1);
                    break;
                case EDateType.Year:
                    _vmcalendar.ShowingDate = _vmcalendar.ShowingDate.AddYears(10);
                    break;
            }
        }
    }
}
