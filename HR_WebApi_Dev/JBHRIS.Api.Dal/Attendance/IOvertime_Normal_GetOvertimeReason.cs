using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IOvertime_Normal_GetOvertimeReason
    {
        List<OvertimeReasonDto> GetOvertimeReason();
    }
}