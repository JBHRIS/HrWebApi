using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance
{
    public interface ICalendarHolidayRepository
    {
        Dictionary<string, List<CalendarHolidayDto>> GetCalendarHolidayList(WorkschedulecheckEntry workschedulecheckEntry);
    }
}