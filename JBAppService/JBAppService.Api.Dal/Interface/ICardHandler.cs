using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{

    /// <summary>
    /// 沒有使用可以刪除了
    /// </summary>
    public interface ICardHandler
    {
        List<CardAppDetailsDto> GetCardDetail(string Url, string nobr, DateTime BDate, DateTime EDate,  int PageRow = 20, int PageNumber = 1);
    }
}
