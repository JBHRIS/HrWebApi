
using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public class SysUserRoleViewService : ISysUserRoleViewService
    {
        private ISystem_View_SysUserRole _system_View_SysUserRole;

        public SysUserRoleViewService(ISystem_View_SysUserRole system_View_SysUserRole
            )
        {
            _system_View_SysUserRole = system_View_SysUserRole;
        }

        public List<SysUserRoleDto> GetUserRoleView(List<string> nobr)
        {
            return _system_View_SysUserRole.GetUserRoleView(nobr);
        }

        public ApiResult<string> InsertUserRoleView(SysUserRoleEntry sysUserRoleEntry)
        {
            return _system_View_SysUserRole.InsertUserRoleView(sysUserRoleEntry);
        }

        public ApiResult<string> DeleteUserRoleView(SysUserRoleEntry sysUserRoleEntry)
        {
            return _system_View_SysUserRole.DeleteUserRoleView(sysUserRoleEntry);
        }

    }
}
