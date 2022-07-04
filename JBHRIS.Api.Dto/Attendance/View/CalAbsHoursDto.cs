using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class CalAbsHoursDto
    {
        public DateTime AtteendDate { get; set; }
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string Nobr { get; set; }
        public decimal TotHours { get; set; }
        public decimal RealTotHours { get; set; }
        public string Unit { get; set; }
        public decimal WorkHours { get; set; }
        public string HCode { get; set; }
        public string HType { get; set; }
        public string Serno { get; set; }
        public bool Syscreate { get; set; }
        public string AName { get; set; }
        public List<CalAbsHoursDetailDto> CalAbsHoursDetails { get; set; }
    }
}
