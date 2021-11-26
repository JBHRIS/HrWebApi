using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysRoleViewService
    {
        List<SysRoleDto> GetRoleView();
        ApiResult<List<SysRoleDto>> InsertRoleView(SysRoleDto sysRoleDto);
        ApiResult<List<SysRoleDto>> UpdateRoleView(SysRoleDto sysRoleDto);
        ApiResult<List<SysRoleDto>> DeleteRoleView(string Code);
    }
}
