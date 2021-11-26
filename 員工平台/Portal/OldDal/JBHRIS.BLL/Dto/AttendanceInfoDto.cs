using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AttendanceInfoDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string RoteCode { get; set; }
        public string RoteName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public List<Tuple<DateTime, DateTime>> WorkTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> RestTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> OverTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> OtRestTimes { get; set; }
        public List<Tuple<DateTime, DateTime>> AbsTimes { get; set; }
        public List<AttcardDto> CardTimes { get; set; }
        public List<CardDto> CardList { get; set; }
        public int LateMinutes { get; set; }
        public int EarilyMinutes { get; set; }
        public int FlexibleMins { get; set; }
        public bool Absenteeism { get; set; }
        public DateTime LastCardTime { get; set; }
        public string Remark { get; set; }
        public Dto.RoteDto Rote { get; set; }
        public bool NeedUpdate { get; set; }
        public bool CheckError { get; set; }
    }
}
