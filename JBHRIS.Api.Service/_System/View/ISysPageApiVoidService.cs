using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysPageApiVoidService
    {
        List<SysPageToApiVoidDto> GetPageToApiVoidView();
        ApiResult<string> InsertPageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry, string KeyMan);
        ApiResult<string> DeletePageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry);
    }
}
