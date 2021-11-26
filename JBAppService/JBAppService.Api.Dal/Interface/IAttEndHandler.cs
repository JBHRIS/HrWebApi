using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IAttEndHandler
    {
        List<AttEndDetailDto> GetAttEndDetail(string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1);
    }
}
