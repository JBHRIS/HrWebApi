using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AbsenceCancelDto
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
        /// 假別代碼
        /// </summary>
        public string HolidayCode { get; set; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HolidayName { get; set; }
        /// <summary>
        /// 請假日期起
        /// </summary>
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// 請假日期迄
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 請假時間起
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 請假時間迄
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 請假時數/天
        /// </summary>
        public decimal AbsenceAmount { get; set; }
        /// <summary>
        /// 時數單位
        /// </summary>
        public string AbsenceUnit { get; set; }
    }
}