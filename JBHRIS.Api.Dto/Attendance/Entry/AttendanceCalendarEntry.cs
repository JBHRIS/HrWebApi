using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class AttendanceDetailEntry
    {
        /// <summary>
        /// 員工編號列表
        /// </summary>
        public List<string> EmployeeList { get; set; }
        /// <summary>
        /// 出勤種類列表
        /// </summary>
        public List<string> AttendTypeList { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}
