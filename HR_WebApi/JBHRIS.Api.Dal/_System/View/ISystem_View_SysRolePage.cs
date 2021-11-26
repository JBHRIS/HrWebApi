using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal._System.View
{
    public interface ISystem_View_SysRolePage
    {
        List<SysRolePageDto> GetRoleToPageView(string RoleCode);
        List<SysRolePageDto> GetPageToRoleView(string PageCode);
        ApiResult<string> InsertRolePageView(SysRolePageEntry sysRolePageEntry,string  KeyMan);
        ApiResult<string> DeleteRolePageView(SysRolePageEntry sysRolePageEntry);
    }
}
