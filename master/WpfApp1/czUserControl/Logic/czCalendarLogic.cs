using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfApp1.Animation;
using WpfApp1.PubFunc;

namespace WpfApp1.czUserControl.Logic
{
    static class czCalendarLogic
    {
        public static void AddBGAnimation(FrameworkElement control, object source, string path, Color blacksrc)
        {
            Style newstyle = new Style(control.GetType());
            czPubFunc.AddDataTriggerST(newstyle, ColorChangedAnime.AnimeColorChange(control, "Background.(SolidColorBrush.Color)", blacksrc),
               source, path, true);
            czPubFunc.AddDataTriggerST(newstyle, ColorChangedAnime.AnimeColorChange(control, "Background.(SolidColorBrush.Color)", czPubFunc.ColorInversion(blacksrc)),
               source, path, false);
            control.Style = newstyle;
        }

        public static DateTime addYearsExtend(this DateTime date, int year)
        {
            DateTime ret = DateTime.MinValue;
            try
            {
                ret = date.AddYears(year);
            }
            catch(Exception ex)
            {
                if(year > 0)
                {
                    ret = DateTime.MaxValue;
                }
                else if(year < 0)
                {
                    ret = DateTime.MinValue;
                }
            }
            
            return ret;
        }

        public static DateTime addDaysExtend(this DateTime date, int day)
        {
            DateTime ret = DateTime.MinValue;
            try
            {
                ret = date.AddDays(day);
            }
            catch (Exception ex)
            {
                if (day > 0)
                {
                    ret = DateTime.MaxValue;
                }
                else if (day < 0)
                {
                    ret = DateTime.MinValue;
                }
            }
            return ret;
        }

        public static DateTime addMonthsExtend(this DateTime date, int month)
        {
            DateTime ret = DateTime.MinValue;
            try
            {
                ret = date.AddMonths(month);
            }
            catch (Exception ex)
            {
                if (month > 0)
                {
                    ret = DateTime.MaxValue;
                }
                else if (month < 0)
                {
                    ret = DateTime.MinValue;
                }
            }
            return ret;
        }
        //public static void AddOpacityAnimation(FrameworkElement control, object source, string path, double[] opacitysrc, object[] value)
        //{
        //    Style newstyle = new Style(control.GetType());
        //    for(int idx = 0; idx < opacitysrc.Length; ++idx)
        //    {
        //        czPubFunc.AddDataTriggerST(newstyle, ColorChangedAnime.AnimeOpacityChange(control, "Opacity", opacitysrc[idx]),
        //       source, path, value[idx]);
        //    }
        //    control.Style = newstyle;
        //}
    }
}
