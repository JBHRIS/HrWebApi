using System;

namespace JBHR.Att.Attendance.Dto
{
    public class WorkScheduleIssueDto
    {
        /// <summary>
        /// 異常日期
        /// </summary>
        public DateTime IssueDate { get; set; }
        /// <summary>
        /// 檢核種類
        /// </summary>
        public string CheckType { get; set; }
        /// <summary>
        /// 錯誤碼
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}