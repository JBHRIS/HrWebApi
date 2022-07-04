using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class AbnormalViewDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public int ErrorMins { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string ActualOnTime { get; set; }
        public string ActualOffTime { get; set; }
        public string RoteName { get; set; }
        public bool IsCheck { get; set; }
        public string Remark { get; set; }
        public string Serno { get; set; }
        public string RemarkType { get; set; }
    }
}
