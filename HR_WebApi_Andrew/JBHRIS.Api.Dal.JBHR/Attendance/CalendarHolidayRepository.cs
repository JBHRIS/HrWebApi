using JBHRIS.Api.Dal.Attendance;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance
{
    public class CalendarHolidayRepository : ICalendarHolidayRepository
    {
        private IUnitOfWork _unitOfWork;

        public CalendarHolidayRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Dictionary<string, List<CalendarHolidayDto>> GetCalendarHolidayList(WorkschedulecheckEntry workschedulecheckEntry)
        {
            var result = new Dictionary<string, List<CalendarHolidayDto>>();
            var holicodeOfEmps = _unitOfWork.Repository<Basetts>().Reads().Where(p => workschedulecheckEntry.EmployeeList.Contains(p.Nobr)
            && workschedulecheckEntry.DateEnd >= p.Adate && workschedulecheckEntry.DateEnd <= p.Ddate).Select(p => new { p.Nobr, p.HoliCode });

            var calendarData = _unitOfWork.Repository<Holi>().Reads()
                .Where(p => holicodeOfEmps.Select(pp => pp.HoliCode).Distinct().Contains(p.HoliCode)
                && p.HDate >= workschedulecheckEntry.DateBegin
                && p.HDate <= workschedulecheckEntry.DateEnd)
                .Select(p => new { p.HDate, p.HoliCode, p.Holi1, p.Othcode }).ToList();
            var othcodes = _unitOfWork.Repository<Othcode>().Reads().ToList();
            foreach (var emp in workschedulecheckEntry.EmployeeList)
            {
                var holiCode = holicodeOfEmps.FirstOrDefault(p => p.Nobr == emp);
                var calendarOfHolicode = from a in calendarData
                                         join b in othcodes on a.Othcode equals b.Othcode1
                                         select new CalendarHolidayDto { AttendanceDate = a.HDate, HolidayType = b.Stdholi ? "Holiday" : b.Othholi ? "NationalHoliday" : "" };
                result.Add(emp, calendarOfHolicode.ToList());
            }
            return result;
        }
    }
}
