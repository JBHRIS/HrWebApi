using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICard_Normal_SaveAttCard
    {
        ApiResult<string> SaveAttendCard(List<AttCardDto> attCardDtos);
    }
}
