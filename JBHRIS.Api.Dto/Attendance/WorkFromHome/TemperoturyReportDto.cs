using System;

namespace HR_WebApi.Dto.Attendance
{
    public class TemperoturyReportDto
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
        public DateTime AttendDate { get; set; }
        /// <summary>
        /// 回報種類(正常、發燒)
        /// </summary>
        public string ReportType { get; set; }
        /// <summary>
        /// 體溫
        /// </summary>
        public decimal Temperotury { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Description { get; set; }
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