using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IOvertimeService
    {
        List<string> GetPeopleOvertime(AttendanceEntry attendanceEntry);
        List<OvertimeTypeDto> GetOvertimeType();
        ApiResult<OvertimeDto> CalculateOvertime(OvertimeApplyDto overtimeApplyDto);
        ApiResult<string> CheckOvertime(OvertimeDto overtimeDto);
        ApiResult<string> SaveOvertime(List<OvertimeDto> overtimeDtos,string KeyMan);
        List<OvertimeByDateDto> GetOvertimeByDate(OvertimeByDateEntry overtimeByDateEntry);
        ApiResult<List<CheckOvertimeDataDto>> CheckOvertimeData(List<OvertimeByDateDto> overtimeByDateDtos);
    }
}