using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAttend_Abs_Absd_CompositeDal
    {
        ApiResult<string> Insert(AbsBalanceOffsetViewDto o);
        ApiResult<string> Delete(List<CancelLeaveApplyDto> cancelLeaveApplyDtos);
    }
}