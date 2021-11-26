using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IOvertime_Normal_GetOvertimeByDate
    {
        List<OvertimeByDateDto> GetOvertimeByDate(OvertimeByDateEntry overtimeByDateEntry);
    }
}
