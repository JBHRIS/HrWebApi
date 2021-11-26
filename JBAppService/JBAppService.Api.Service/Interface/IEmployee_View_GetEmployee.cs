using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IEmployee_View_GetEmployee
    {
        List<ApiRolesDto> GetApiRoles(List<string> Nobr);
    }
}
