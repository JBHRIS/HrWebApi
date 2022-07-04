using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysApiVoidService
    {
        List<SysApiVoidDto> GetApiVoidView();
        ApiResult<string> InsertApiVoidView(SysApiVoidDto sysApiVoidDto);
        ApiResult<string> UpdateApiVoidView(SysApiVoidDto sysApiVoidDto);
        ApiResult<string> DeleteApiVoidView(string Code);
    }
}
