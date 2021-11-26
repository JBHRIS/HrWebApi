using JBHRIS.Api.Dto.Attendance.Normal;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICard_Normal_GetCardApply
    {
        List<CardApplyDto> GetCardApplys();
    }
}