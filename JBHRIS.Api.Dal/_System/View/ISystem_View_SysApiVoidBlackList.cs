using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal._System.View
{
    public interface ISystem_View_SysApiVoidBlackList
    {
        List<SysApiVoidBlackListDto> GetApiVoidBlackListView(List<string> nobr);
        ApiResult<string> InsertApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry, string KeyMan);
        ApiResult<string> DeleteApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry);
    }
}
