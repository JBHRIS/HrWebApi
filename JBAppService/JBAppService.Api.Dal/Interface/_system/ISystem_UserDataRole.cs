using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface._system
{
    public interface ISystem_UserDataRole
    {
        List<HrDataRoleDto> GetDataRolesById(string userId);
    }
}
