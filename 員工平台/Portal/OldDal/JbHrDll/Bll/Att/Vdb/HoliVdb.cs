using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class HoliVdb
    {
    }

    public class HoliRow
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 是否假日
        /// </summary>
        public bool Holi { get; set; }
        /// <summary>
        /// 行事曆代碼
        /// </summary>
        public string HoliCode { get; set; }
        /// <summary>
        /// 假日加班代碼
        /// </summary>
        public string OtHcode { get; set; }
    }
}