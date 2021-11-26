using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Dto
{
    public class AttendDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendDate { get; set; }
        public string Rote { get; set; }
        public string RoteName { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
        public int LateMins { get; set; }
        public int EarilyMins { get; set; }
        public bool ABS { get; set; }
        public DateTime? CardTimeBegin { get; set; }
        public DateTime? CardTimeEnd { get; set; }
        public List<Tuple<string, string>> AttRecords { get; set; }
        public decimal WorkHours { get; internal set; }
    }
}
