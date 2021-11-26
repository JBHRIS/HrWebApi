using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttendCardDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeID { get; set; }
        /// <summary>
        /// 出勤打卡日期
        /// </summary>
        public DateTime PuchInDate { get; set; }
        /// <summary>
        /// 打卡上班時間
        /// </summary>
        public string PuchInOnTime { get; set; }
        /// <summary>
        /// 打卡下班時間
        /// </summary>
        public string PuchInOffTime { get; set; }
        public string Code { get; set; }
        public decimal Ser { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Dd1 { get; set; }
        public string Dd2 { get; set; }
        public bool Lost1 { get; set; }
        public bool Lost2 { get; set; }
        public string Tt1 { get; set; }
        public string Tt2 { get; set; }
        public bool Nomody { get; set; }
    }
}
