using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class RoteChangeDto
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
        /// 調班日期
        /// </summary>
        public DateTime RoteChangeDate { get; set; }
        /// <summary>
        /// 調班班別代碼
        /// </summary>
        public string Rote { get; set; }
        /// <summary>
        /// 調班班別名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 資料序號
        /// </summary>
        public int AutoKey { get; set; }
    }
}