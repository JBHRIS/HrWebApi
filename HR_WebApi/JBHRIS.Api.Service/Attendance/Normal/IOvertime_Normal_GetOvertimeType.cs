using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IOvertime_Normal_GetOvertimeType
    {
        List<OvertimeTypeDto> GetOvertimeType();
    }
}