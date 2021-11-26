using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class AttRoteViewDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendDate { get; set; }
        public string RoteCode { get; set; }
        public string RoteName { get; set; }
        public DateTime RoteOnTime { get; set; }
        public DateTime RoteOffTime { get; set; }
        public string RoteOffTime2 { get; set; }
        public List<Tuple<DateTime, DateTime>> RoteRestTime { get; set; }
        public decimal WorkHours { get; set; }
        public AttendDto Attend { get; set; }
        public BasettsDto Basetts { get; set; }
        public RoteDto Rote { get; set; }
    }
}
