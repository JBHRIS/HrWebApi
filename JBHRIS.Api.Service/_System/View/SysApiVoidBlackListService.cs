using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public class SysApiVoidBlackListService : ISysApiVoidBlackListService
    {
        private ISystem_View_SysApiVoidBlackList _system_View_SysApiVoidBlackList;

        public SysApiVoidBlackListService(ISystem_View_SysApiVoidBlackList system_View_SysApiVoidBlackList
            )
        {
            _system_View_SysApiVoidBlackList = system_View_SysApiVoidBlackList;
        }

        public List<SysApiVoidBlackListDto> GetApiVoidBlackListView(List<string> nobr)
        {
            return _system_View_SysApiVoidBlackList.GetApiVoidBlackListView(nobr);
        }

        public ApiResult<string> InsertApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry, string KeyMan)
        {
            return _system_View_SysApiVoidBlackList.InsertApiVoidBlackListView(sysApiVoidBlackListEntry, KeyMan);
        }

        public ApiResult<string> DeleteApiVoidBlackListView(SysApiVoidBlackListEntry sysApiVoidBlackListEntry)
        {
            return _system_View_SysApiVoidBlackList.DeleteApiVoidBlackListView(sysApiVoidBlackListEntry);
        }
    }
}
