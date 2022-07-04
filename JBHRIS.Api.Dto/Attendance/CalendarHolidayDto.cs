using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CalendarHolidayDto
    {
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendanceDate { get; set; }
        /// <summary>
        /// 假日類別=>
        /// 國定假日：NationalHoliday
        /// 例假日：Holiday
        /// 休息日：Offday
        /// </summary>
        public string HolidayType { get; set; }
    }
}