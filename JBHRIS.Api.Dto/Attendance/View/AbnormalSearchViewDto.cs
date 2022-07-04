using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class AbnormalSearchViewDto
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
        /// 部門代碼
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { get; set; }
        /// <summary>
        /// 異常種類
        /// </summary>
        public string AbnormalType { get; set; }
        /// <summary>
        /// 異常種類名稱
        /// </summary>
        public string AbnormalName { get; set; }
        /// <summary>
        /// 異常分鐘數
        /// </summary>
        public int AbnormalErrorMins { get; set; }
        /// <summary>
        /// 班別上班時間
        /// </summary>
        public string RoteOnTime { get; set; }
        /// <summary>
        /// 班別下班時間
        /// </summary>
        public string RoteOffTime { get; set; }
        /// <summary>
        /// 刷卡上班時間
        /// </summary>
        public string CardOnTime { get; set; }
        /// <summary>
        /// 刷卡下班時間
        /// </summary>
        public string CardOffTime { get; set; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 已註記
        /// </summary>
        public bool IsCheck { get; set; }
        /// <summary>
        /// 註記類型
        /// </summary>
        public string RemarkType { get; set; }
        /// <summary>
        /// 註記說明
        /// </summary>
        public string RemarkTypeName { get; set; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { get; set; }
    }
}
