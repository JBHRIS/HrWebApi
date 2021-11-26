using JBHRIS.Api.Dto.Attendance;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface ICard_Normal_GetCardReason
    {
        List<CardReasonDto> GetCardReason();
    }
}