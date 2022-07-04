using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IAttend_Normal_UpdateAttend
    {
        ApiResult<string> UpdateAttend(List<AttendDto> attendanceDtos);
    }
}
