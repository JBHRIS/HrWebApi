using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.WorkFromHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IDiversionAttendType_Normal_GetDiversionAttendType
    {
        ApiResult<List<DiversionAttendTypeDto>> GetDiversionAttendTypes(List<string> DiversionAttendTypes);
    }
}
