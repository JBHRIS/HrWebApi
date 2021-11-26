using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICard_Normal_GetCardReason
    {
        List<CardReasonDto> GetCardReason();
    }
}