using System;

namespace JBHRIS.Api.Dto.Attendance
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
        public string Remark { get; set; }
        public string Color { get; set; }
        public decimal Use { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }

    }
}