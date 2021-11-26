using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CardDto
    {
        public DateTime AttendanceDate { get; set; }
        public string CardNumber { get; set; }
        public string Source { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateMan { get; set; }
        public bool IsForget { get; set; }
        public string Remark { get; set; }
        public string EmployeeId { get; set; }
        public bool IsLock { get; set; }
        public string CheckTime { get; set; }
        public string Reason { get; set; }
        public string SerialNumber { get; set; }
    }
}