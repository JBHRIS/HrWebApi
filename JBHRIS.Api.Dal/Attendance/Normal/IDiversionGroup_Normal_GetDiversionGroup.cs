using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Attendance.Normal
{
    public interface IDiversionGroup_Normal_GetDiversionGroup
    {
        ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry);
    }
}
