using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance
{
    public class WorkScheduleCheckResult:StatusResultDto
    {
        /// <summary>
        /// 錯誤紀錄
        /// </summary>
        public List<WorkScheduleIssueDto> workScheduleIssues { get; set; }
    }
}