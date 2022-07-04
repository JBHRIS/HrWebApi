using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysApiVoidWhiteListService
    {
        List<SysApiVoidWhiteListDto> GetApiVoidWhiteListView(List<string> nobr);
        ApiResult<string> InsertApiVoidWhiteListView(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry,string KeyMan);
        ApiResult<string> DeleteApiVoidWhiteListView(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry);
    }
}
