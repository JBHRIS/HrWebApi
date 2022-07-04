using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAbsenceCancel_Normal_GetCancelableLeave
    {
        ApiResult<List<CancelLeaveApplyDto>> GetCancelableLeave(DateBetweenQueryDto dateBetweenQueryDto);
    }
}
