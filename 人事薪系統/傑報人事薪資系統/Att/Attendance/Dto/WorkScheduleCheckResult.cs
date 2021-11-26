using System.Collections.Generic;

namespace JBHR.Att.Attendance.Dto
{
    public class WorkScheduleCheckResult
    {
        /// <summary>
        /// 狀態
        /// (true正常/false異常)
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 錯誤紀錄
        /// </summary>
        public List<WorkScheduleIssueDto> workScheduleIssues { get; set; }
    }
}