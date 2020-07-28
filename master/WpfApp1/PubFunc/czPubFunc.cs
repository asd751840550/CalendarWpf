using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp1.PubFunc
{
    public class czPubFunc
    {
        public static void SetControlBinding(FrameworkElement con, DependencyProperty property, object source, string path, IValueConverter converter = null, object converterparameter = null)
        {
            con.SetBinding(property, new Binding() { Mode = BindingMode.Default, Source = source, Path = new PropertyPath(path), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Converter = converter, ConverterParameter = converterparameter });
        }

        public static void AddDataTriggerST(Style style, Storyboard st, object souce, string path, object value)
        {
            string guid = "B" + GetGuid().Replace("-","");
            DataTrigger data = new DataTrigger();
            BeginStoryboard beginst = new BeginStoryboard() { Storyboard = st, Name = guid };
            data.Binding = new Binding(path) { Source = souce, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
            style.RegisterName(guid, beginst);
            data.Value = value;
            data.EnterActions.Add(beginst);
            data.ExitActions.Add(new StopStoryboard() { BeginStoryboardName = guid });
            style.Triggers.Add(data);
        }

        public static Color ColorInversion(Color srcc)
        {
            return Color.FromRgb((byte)(255 - srcc.R), (byte)(255 - srcc.G), (byte)(255 - srcc.B));
        }

        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
