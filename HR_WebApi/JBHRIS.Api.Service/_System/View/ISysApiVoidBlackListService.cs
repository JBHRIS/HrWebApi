using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public interface ISysApiVoidBlackListService
    {
        List<SysApiVoidBlackListDto> GetApiVoidBlackListView(List<string> nobr);
        ApiResult<string> InsertApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry, string KeyMan);
        ApiResult<string> DeleteApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry);
    }
}
