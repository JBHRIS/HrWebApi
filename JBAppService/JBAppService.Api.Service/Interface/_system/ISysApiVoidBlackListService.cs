using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface._system
{
    public interface ISysApiVoidBlackListService
    {
        

        List<SysApiVoidBlackListDto> GetApiVoidBlackListView(List<string> nobr);
    }
}
