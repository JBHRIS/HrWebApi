using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IShiftChange_Normal_CheckDayShiftChange
    {
        ApiResult<string> CheckDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto);
    }
}