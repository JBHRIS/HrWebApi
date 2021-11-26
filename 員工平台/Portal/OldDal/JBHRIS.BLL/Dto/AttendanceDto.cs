using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AttendanceDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime WorkBeginTime { get; set; }
        public DateTime WorkEndTime { get; set; }
        public string WorkType { get; set; }
        public List<Tuple<DateTime, DateTime>> RestTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> OtRestTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> CheckRestTimes { get; set; }
        public bool CheckError { get; set; }
    }
}
