using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class RoteDto
    {
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteCode { get; set; }
        public string RoteDisp { get; set; }
        public string Rotename { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string OffTime2 { get; set; }
        public string AttEnd { get; set; }
        public string OtBegin { get; set; }
        public int Sort { get; set; }
    }
}