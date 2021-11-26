using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CardDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeID { get; set; }
        /// <summary>
        /// 打卡日期
        /// </summary>
        public DateTime PuchInDate { get; set; }
        /// <summary>
        /// 打卡時間
        /// </summary>
        public string PuchInTime { get; set; }
        /// <summary>
        /// 來源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 忘刷
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
        /// <summary>
        /// 是否累計忘刷次數
        /// </summary>
        public bool IsAddForgetTime { get; set; }
        /// <summary>
        /// 卡片來源(卡機orWeb)
        /// </summary>
        public string Code { get; set; }
    }
}