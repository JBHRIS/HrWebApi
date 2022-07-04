using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IDiversionGroupService
    {
        ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry);
        ApiResult<string> InsertDiversionGroup(DiversionGroupDto diversionGroupDto);
        ApiResult<string> UpdateDiversionGroup(DiversionGroupDto diversionGroupDto);
        ApiResult<string> DeleteDiversionGroup(DiversionGroupDto diversionGroupDto);

    }
}
