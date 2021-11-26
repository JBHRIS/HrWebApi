using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class CardSearchViewDto
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
        /// 打卡日期
        /// </summary>
        public DateTime PuchInDate { get; set; }
        /// <summary>
        /// 打卡時間
        /// </summary>
        public string PuchInTime { get; set; }
        /// <summary>
        /// 是否忘刷
        /// </summary>
        public bool Forget { get; set; }
        /// <summary>
        /// 忘刷原因
        /// </summary>
        public string ForgetReason { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Remarks { get; set; }
    }
}
