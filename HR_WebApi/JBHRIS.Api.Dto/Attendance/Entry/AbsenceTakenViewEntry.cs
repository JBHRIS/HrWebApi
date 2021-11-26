using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    /// <summary>
    /// 請假查詢_查詢條件
    /// </summary>
    public class AbsenceTakenViewEntry
    {
        /// <summary>
        /// 員工編號清單
        /// </summary>
        public List<string> EmployeeList { get; set; }
        /// <summary>
        /// 假別代碼清單
        /// </summary>
        public List<string> LeaveCodeList { get; set; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}