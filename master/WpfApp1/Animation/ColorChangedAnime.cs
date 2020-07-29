using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfApp1.PubFunc;

namespace WpfApp1.Animation
{
    public class ColorChangedAnime
    {
        public static Storyboard AnimeColorChange(object target, string path, Color srcc)
        {
            Storyboard st = new Storyboard();
            if (target is FrameworkElement tar)
            {
                ColorAnimation ca = new ColorAnimation();
                Color dstc = czPubFunc.ColorInversion(srcc);
                ca.From = srcc;
                ca.To = dstc;
                ca.Duration = TimeSpan.FromSeconds(1);
                
                Storyboard.SetTarget(ca, tar);                    
                Storyboard.SetTargetProperty(ca, new PropertyPath(path));
                st.Children.Add(ca);
                st.Begin();
                tar.GetType().GetProperty("Background")?.SetValue(tar, new SolidColorBrush(dstc));
            }
            return st;
        }

        //public static Storyboard AnimeOpacityChange(object target, string path, double srcop)
        //{
        //    Storyboard st = new Storyboard();
        //    if (target is FrameworkElement tar)
        //    {
        //        DoubleAnimation ca = new DoubleAnimation();
        //        double dstop = 100 - srcop;
                
        //        ca.To = dstop;
        //        ca.Duration = TimeSpan.FromMilliseconds(600);
        //        //ca.SpeedRatio = 1.5;

        //        Storyboard.SetTarget(ca, tar);
        //        Storyboard.SetTargetProperty(ca, new PropertyPath(path));
        //        st.Children.Add(ca);
        //        st.Begin();
        //        //tar.GetType().GetProperty(path)?.SetValue(tar, dstop);
        //        //if (srcop == 100)
        //        //{
        //        //    tar.GetType().GetProperty("Visibility")?.SetValue(tar, Visibility.Hidden);
        //        //}
        //    }
        //    return st;
        //}
    }
}
