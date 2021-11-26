using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance
{
    /// <summary>
    /// 排班檢核輸入條件
    /// </summary>
    public class WorkScheduleCheckEntry
    {
        public WorkScheduleCheckEntry()
        {
            CheckTypes = new List<string>();
        }
        /// <summary>
        /// 檢核種類
        /// </summary>
        public List<string> CheckTypes { get; set; }
        /// <summary>
        /// 檢核條件
        /// </summary>
        public WorkScheduleCheckDto workScheduleCheck { get; set; }
    }
}