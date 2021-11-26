using System;

namespace HR_WebApi.Dto.Attendance
{
    public class WorkLogDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 員工姓名(顯示用)
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate{ get; set; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 工作時數
        /// </summary>
        public decimal WorkHours { get; set; }
        /// <summary>
        /// 工作項目內容
        /// </summary>
        public string Workitem { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 附件Id
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// 資料輸入人員
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        public Guid Guid { get; set; }
    }
}