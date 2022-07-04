using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal._System.View
{
    public interface ISystem_View_SysPageApiVoid
    {
        public List<SysPageApiVoidDto> GetPageApiVoidView(string PageCode);
        ApiResult<string> InsertPageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry, string KeyMan);
        ApiResult<string> DeletePageApiVoidView(SysPageApiVoidEntry sysPageApiVoidEntry);
    }
}
