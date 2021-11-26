using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AttendDto
    {
        public string EmployeeID { get; set; }
        public string RoteCode { get; set; }
        public string RoteCodeCheck { get; set; }
        public DateTime AttendanceDate { get; set; }
        public List<Tuple<DateTime, DateTime>> WorkTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> RestTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> OtRestTimes { get; set; }
        public int LateMinutes { get; set; }
        public int EarilyMinutes { get; set; }
        public int FlexibleMins { get; set; }
        public bool Absenteeism { get; set; }        
        public DateTime FirstCardTime { get; set; }
        public DateTime LastCardTime { get; set; }
        public string Remark { get; set; }               
        public bool CheckError { get; set; }
        public string CreateMan { get; set; }               
        
    }
}
