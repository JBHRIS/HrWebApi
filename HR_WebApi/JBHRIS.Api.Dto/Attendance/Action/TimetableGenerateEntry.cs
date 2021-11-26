using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance.Action
{
    public class TimetableGenerateEntry
    {
        public List<string> employeeList { get; set; }
        public string Yymm { get; set; }
        /// <summary>
        /// 完整模式：
        /// <True>完整跑完所有紀錄</True>
        /// <False>只針對過期資料進行運算</False>
        /// </summary>
        public bool FullMode { get; set; } = false;
    }
}