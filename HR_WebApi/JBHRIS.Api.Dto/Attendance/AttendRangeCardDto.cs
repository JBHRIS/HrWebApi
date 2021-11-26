using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttendRangeCardDto
    {   
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeID { get; set; }
        /// <summary>
        /// 出勤歸屬日
        /// </summary>
        public DateTime AttendDate { get; set; }
        /// <summary>
        /// 當日收卡起始時間
        /// </summary>
        public DateTime? GetCardOnTime { get; set; }
        /// <summary>
        /// 當日收卡結束時間
        /// </summary>
        public DateTime? GetCardOffTime { get; set; }
        /// <summary>
        /// 當日打卡起始時間
        /// </summary>
        public string AttendCardOnTime { get; set; }
        /// <summary>
        /// 當日打卡結束時間
        /// </summary>
        public string AttendCardOffTime { get; set; }
        /// <summary>
        /// 當日打卡資料
        /// </summary>
        public List<CardDto> Cards { get; set; }
    }
}
