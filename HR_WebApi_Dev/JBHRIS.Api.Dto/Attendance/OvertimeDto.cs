using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class OvertimeDto
    {
        public string EmployeeId { get; set; }
        public DateTime OvertimeDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public decimal TotalHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal RestHours { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateMan { get; set; }
        public string OvertimeRote { get; set; }
    }
}