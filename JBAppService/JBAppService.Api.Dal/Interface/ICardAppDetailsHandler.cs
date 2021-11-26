using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Interface
{
    public interface ICardAppDetailsHandler
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        int SaveCardDetails(SaveCardAppDetailsDto Dto, bool NotTran, string Code);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        int SaveCardDetailsNotCard(SaveCardAppDetailsDto Dto, bool NotTran, bool tag);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="BDate"></param>
        /// <param name="EDate"></param>
        /// <param name="PageRow"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        List<CardRowDataDto> GetCardDetail(string Url, string Nobr, DateTime BDate, DateTime EDate, int PageRow = 20, int PageNumber = 1);
        /// <summary>
        ///
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="APP_RegistryKey"></param>
        /// <returns></returns>
        bool CheckAPP_RegistryKey(string Nobr, string APP_RegistryKey);
        /// <summary>
        /// 檢查同一分鐘卡
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="notTran"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        bool SaveCardMsg(SaveCardAppDetailsDto dto, bool notTran, string code);
    }
}