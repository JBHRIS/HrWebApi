using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal._System.View
{
    public interface ISystem_View_SysUserRole
    {
        List<SysUserRoleDto> GetUserRoleView(List<string> nobr);
        List<string> GetUserDepartmentExtra(string nobr);
        ApiResult<string> InsertUserRoleView(SysUserRoleEntry sysUserRoleEntry);
        ApiResult<string> DeleteUserRoleView(SysUserRoleEntry sysUserRoleEntry);
    }
}
