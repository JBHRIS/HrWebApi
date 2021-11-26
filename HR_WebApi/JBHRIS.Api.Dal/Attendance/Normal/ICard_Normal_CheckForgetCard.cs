using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICard_Normal_CheckForgetCard
    {
        ApiResult<string> CheckForgetCard(ForgetCardApplyDto forgetCardApplyDto);
    }
}