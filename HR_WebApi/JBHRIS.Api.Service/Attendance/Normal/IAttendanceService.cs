using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAttendanceService
    {
        List<AttendanceDto> GetAttendance(AttendanceRoteEntry attendanceEntry);

        List<RoteChangeDto> GetRoteChange(AttendanceRoteEntry attendanceEntry);

        List<string> GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry);

        List<string> GetPeopleWork(AttendanceRoteEntry attendanceEntry);
        List<AttendanceTypeDto> GetAttendType();
        List<RoteDto> GetRote(string RoteCode);

        ApiResult<List<CalendarDto>> GetCalendar(AttendanceCalendarEntry attendanceCalendarEntry);

        ApiResult<List<AttendanceDetailDto>> GetAttendDetail(AttendanceDetailEntry attendanceDetailEntry);

        ApiResult<string>  UpdateAttendRote(UpdateAttendRoteEntry updateAttendRoteEntry,string keyman);

        ApiResult<string> InsertAttend(List<AttendDto> attendanceDtos);

        ApiResult<string> UpdateAttend(List<AttendDto> attendanceDtos);

        CheckDataHaveAttLockDto CheckDataHaveAttLock(JBHRIS.Api.Dto.Files.TmtableImportDto tmtable, List<DateTime> lockAttDateList);

    }
}