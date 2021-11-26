using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class AbnormalSearchViewEntry
    {
        /// <summary>
        /// 員工編號清單
        /// </summary>
        public List<string> EmployeeList { get; set; }
        /// <summary>
        /// 開始日期起
        /// </summary>
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// 結束日期迄
        /// </summary>
        public DateTime DateEnd { get; set; }
        /// <summary>
        /// 是否未註記
        /// </summary>
        public bool IsNoCheck { get; set; }
    }
}
