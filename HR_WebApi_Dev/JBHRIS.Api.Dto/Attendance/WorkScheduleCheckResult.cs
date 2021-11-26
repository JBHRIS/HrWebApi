using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance
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