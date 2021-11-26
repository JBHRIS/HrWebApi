using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class OvertimeDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeID { get; set; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 加班日期
        /// </summary>
        public DateTime OverTimeDate { get; set; }
        /// <summary>
        /// 加班時間起
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 加班時間迄
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 加班班別
        /// </summary>
        public string OverTimeRote { get; set; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string OverTimeRoteName { get; set; }
        /// <summary>
        /// 加班原因
        /// </summary>
        public string OverTimeReason { get; set; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public Decimal OverTimeHours { get; set; }
        /// <summary>
        /// 補休時數
        /// </summary>
        public Decimal RestTimeHours { get; set; }
        /// <summary>
        /// 編號
        /// </summary>
        public string SerialNumber { get; set; }
    }
}