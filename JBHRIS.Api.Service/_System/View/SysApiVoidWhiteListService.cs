using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service._System.View
{
    public class SysApiVoidWhiteListService : ISysApiVoidWhiteListService
    {
        private ISystem_View_SysApiVoidWhiteList _system_View_SysApiVoidWhiteList;

        public SysApiVoidWhiteListService(ISystem_View_SysApiVoidWhiteList system_View_SysApiVoidWhiteList
            )
        {
            _system_View_SysApiVoidWhiteList = system_View_SysApiVoidWhiteList;
        }

        public List<SysApiVoidWhiteListDto> GetApiVoidWhiteListView(List<string> nobr)
        {
            return _system_View_SysApiVoidWhiteList.GetApiVoidWhiteListView(nobr);
        }

        public ApiResult<string> InsertApiVoidWhiteListView(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry, string KeyMan)
        {
            return _system_View_SysApiVoidWhiteList.InsertApiVoidWhiteListView(sysApiVoidWhiteListEntry, KeyMan);
        }

        public ApiResult<string> DeleteApiVoidWhiteListView(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry)
        {
            return _system_View_SysApiVoidWhiteList.DeleteApiVoidWhiteListView(sysApiVoidWhiteListEntry);
        }
    }
}
