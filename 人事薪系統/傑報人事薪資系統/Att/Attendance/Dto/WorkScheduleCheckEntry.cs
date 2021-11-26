using System;
using System.Collections.Generic;

namespace JBHR.Att.Attendance.Dto
{
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