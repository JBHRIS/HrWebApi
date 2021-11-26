using System;

namespace JBHRIS.Api.Dto.Attendance.Action
{
    public class EmployeeInfo_HoliCode
    {
        public string EmployeeId { get; set; }
        public DateTime Adate { get;  set; }
        public DateTime Ddate { get; set; }
        public string Calendar { get; set; }
        public string Rotet { get; set; }
        public int LastSequnce { get; set; }
    }
}