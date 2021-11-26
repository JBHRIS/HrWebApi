using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAttCardService
    {
        List<AttendCardDto> GetAttendCard(AttendanceEntry attendanceEntry);
        ApiResult<string> SaveAttendCard(List<AttCardDto> attCardDtos);
        ApiResult<string> UpdateAttCard(List<AttCardDto> attCardDtos);
    }
}
