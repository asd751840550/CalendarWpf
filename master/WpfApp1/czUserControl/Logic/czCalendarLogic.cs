using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfApp1.Animation;
using WpfApp1.PubFunc;

namespace WpfApp1.czUserControl.Logic
{
    class czCalendarLogic
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
