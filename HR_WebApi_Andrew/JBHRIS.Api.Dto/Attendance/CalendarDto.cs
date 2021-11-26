using System;

namespace JBHRIS.Api.Attendance
{
    /// <summary>
    /// 行事曆
    /// </summary>
    public class CalendarDto
    {
        public string EmployeeId { get; set; }
        public DateTime CalendarDate { get; set; }
        public string CalendarType { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public double Color { get; set; }

    }
}