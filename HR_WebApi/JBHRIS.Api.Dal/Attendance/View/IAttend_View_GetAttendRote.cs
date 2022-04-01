using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.View
{
    public interface IAttend_View_GetAttendRote
    {
        List<AttRoteViewDto> GetAttRote(List<string> EmpIds,DateTime StartDate, DateTime EndDate);
        List<AttRoteViewDto> GetAttRoteH(List<string> EmpIds, DateTime StartDate, DateTime EndDate);
        List<AttentRoteViewDto> GetAttendRoteView(AttendanceEntry attendanceEntry);
        List<RoteDto> GetRote(string RoteCode);
        List<RoteDto> GetRotes();
        ApiResult<string> UpdateAttendRote(UpdateAttendRoteEntry updateAttendRoteEntry,string keyman);
        List<AttendanceTypeDto> GetAttendType();
    }
}
