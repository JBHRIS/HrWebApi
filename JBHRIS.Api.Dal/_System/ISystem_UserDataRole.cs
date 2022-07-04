using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal._System
{
    public interface ISystem_UserDataRole
    {
        List<string> GetDataGroup();
        List<HrDataRoleDto> GetDataRolesById(string userId);
        ApiResult<string> SetPresetRole(string Nobr);
    }
}