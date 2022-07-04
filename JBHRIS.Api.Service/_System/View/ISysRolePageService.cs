using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysRolePageService
    {
        List<SysRoleToPageDto> GetRoleToPageView();
        List<SysPageToRoleDto> GetPageToRoleView();
        ApiResult<string> InsertRolePageView(SysRolePageEntry sysRolePageEntry, string KeyMan);
        ApiResult<string> DeleteRolePageView(SysRolePageEntry sysRolePageEntry);
    }
}
