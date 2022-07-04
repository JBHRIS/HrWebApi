using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface ICard_Normal_UpdateAttCard
    {
        ApiResult<string> UpdateAttCard(List<AttCardDto> attCardDtos);
    }
}
