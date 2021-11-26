using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface._system
{
    public interface ISystem_View_SysApiVoidWhiteList
    {
        List<SysApiVoidWhiteListDto> GetApiVoidWhiteListView(List<string> nobr);
    }
}
