using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dto;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;

namespace JBAppService.Api.Service.Implement
{
    public class CardHandlerService : ICardHandlerService
    {
        private ICardAppDetailsHandler _ICardAppDetailsHandler;

        public CardHandlerService(ICardAppDetailsHandler cardAppDetailsHandler)
        {
            this._ICardAppDetailsHandler = cardAppDetailsHandler;
        }

        public bool CheckAPP_RegistryKey(string Nobr, string APP_RegistryKey)
        {
            return this._ICardAppDetailsHandler.CheckAPP_RegistryKey(Nobr, APP_RegistryKey);
        }

        public List<CardRowDataDto> GetCardDetail(string Url, string Nobr, DateTime BDate, DateTime EDate, int PageRow, int PageNumber)
        {
            return this._ICardAppDetailsHandler.GetCardDetail(Url, Nobr, BDate, EDate, PageRow, PageNumber);
        }

        public int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code)
        {
            return this._ICardAppDetailsHandler.SaveCardDetails(Dto, NotTran, Code);
        }
        public int SaveCardDetailsNotCard(SaveCardAppDetailsDto Dto, bool NotTran, bool tag)
        {
            return this._ICardAppDetailsHandler.SaveCardDetailsNotCard(Dto, NotTran, tag);
        }
        public bool SaveCardMsg(SaveCardAppDetailsDto Dto, bool NotTran, string Code)
        {
            return _ICardAppDetailsHandler.SaveCardMsg(Dto, NotTran, Code);
        }
    }
}