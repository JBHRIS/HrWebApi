using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAbnormalService
    {
        List<AbnormalViewDto> GetAbnormalViewDtos(AttendanceEntry attendanceEntry);
        List<AbnormalViewDto> GetAbnormalViewDtosByCheckFalse(AttendanceEntry attendanceEntry);
        ApiResult<string> SaveAbnormalAttendanceComment(List<AbnormalViewDto> abnormalViewDtos, string KeyMan);
    }
}
