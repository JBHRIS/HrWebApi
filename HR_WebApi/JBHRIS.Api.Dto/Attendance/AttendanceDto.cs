using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttendanceDto
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime AttendDate { get; set; }
        /// <summary>
        /// 班別顯示代碼
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 班別上班時間
        /// </summary>
        public string RoteDateB { get; set; }
        /// <summary>
        /// 班別上班時間
        /// </summary>
        public string RoteTimeB { get; set; }
        /// <summary>
        /// 班別下班時間
        /// </summary>
        public string RoteDateE { get; set; }
        /// <summary>
        /// 班別下班時間
        /// </summary>
        public string RoteTimeE { get; set; }
        /// <summary>
        /// 刷卡上班時間
        /// </summary>
        public string CardDateB { get; set; }
        /// <summary>
        /// 刷卡上班時間
        /// </summary>
        public string CardTimeB { get; set; }
        /// <summary>
        /// 刷卡下班時間
        /// </summary>
        public string CardDateE { get; set; }
        /// <summary>
        /// 刷卡下班時間
        /// </string>
        public string CardTimeE { get; set; }
        /// <summary>
        /// 遲到分鐘數
        /// </summary>
        public decimal LateMin { get; set; }
        /// <summary>
        /// 早退分鐘數
        /// </summary>
        public decimal EarlyMin { get; set; }
        /// <summary>
        /// 是否曠職
        /// </summary>
        public bool IsAbs { get; set; }
        /// <summary>
        /// 忘刷分鐘數
        /// </summary>
        public decimal Forget { get; set; }
    }
}