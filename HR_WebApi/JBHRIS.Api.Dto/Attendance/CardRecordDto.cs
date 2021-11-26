using System;

namespace JBHRIS.Api.Dto.Attendance.Normal
{
    public class CardRecordDto
    {
        public string EmployeeId { get;  set; }
        public DateTime CardDate { get;  set; }
        public string CardTime { get;  set; }
        public string Source { get;  set; }
    }
}