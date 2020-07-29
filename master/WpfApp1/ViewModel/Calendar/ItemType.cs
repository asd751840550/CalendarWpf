using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.ViewModel.Calendar
{
    /// <summary>
    /// ListBoxItem对应
    /// </summary>
    public class ItemType
    {
        /// <summary>
        /// 当前日期
        /// </summary>
        public DateTime CurDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 当前Item的状态
        /// </summary>
        public EDateType DateType { get; set; } = EDateType.Days;

        /// <summary>
        /// Item背景色
        /// </summary>
        public Color BGColor { get; set; } = Colors.White;

        /// <summary>
        /// Item备注
        /// </summary>
        public string TypeRemarks { get; set; } = string.Empty;

        /// <summary>
        /// Item透明度
        /// </summary>
        public double Opacity { get; set; } = 1;

        public ItemType()
        {

        }

        public override string ToString()
        {
            return CurDate.ToString();
        }
    }
}
