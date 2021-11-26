using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;

namespace JBAppService.Api.Service.Interface
{
    public interface ICardHandlerService
    {
        int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code);
        int SaveCardDetailsNotCard(SaveCardAppDetailsDto Dto, bool NotTran, bool tag);
        List<CardRowDataDto> GetCardDetail(string Url, string Nobr, DateTime BDate, DateTime EDate, int PageRow, int PageNumber);
        bool CheckAPP_RegistryKey(string Nobr, string APP_RegistryKey);
        bool SaveCardMsg(SaveCardAppDetailsDto Dto, bool NotTran, string Code);
    }
}