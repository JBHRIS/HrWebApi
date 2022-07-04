using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface ITransCardService
    {
        ApiResult<string> TransCard(TransCardEntry transCardEntry,string KeyMan);
        List<AttendRangeCardDto> GetAttendRangeCard(TransCardEntry transCardEntry);
    }
}
