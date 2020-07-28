using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.ViewModel.Calendar
{
    public class ItemType
    {
        public DateTime CurDate { get; set; } = DateTime.Now;

        public EDateType DateType { get; set; } = EDateType.Days;

        public Color BGColor { get; set; } = Colors.White;

        public string TypeRemarks { get; set; } = string.Empty;

        public ItemType()
        {

        }

        public override string ToString()
        {
            return CurDate.ToString();
        }
    }
}
