using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class AbsenceBalanceEntry
    {
        /// <summary>
        /// 員工編號清單
        /// </summary>
        public List<string> EmployeeList { get; set; }
        /// <summary>
        /// 假別類別清單
        /// </summary>
        public List<string> HtypeList { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime EffectDate { get; set; }
    }
}
