using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysUserRoleViewService
    {
        List<SysUserRoleDto> GetUserRoleView(List<string> nobr);
        ApiResult<string> InsertUserRoleView(SysUserRoleEntry sysUserRoleEntry);
        ApiResult<string> DeleteUserRoleView(SysUserRoleEntry sysUserRoleEntry);
    }
}
