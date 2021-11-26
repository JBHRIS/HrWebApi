using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IBaseHandlerService
    {
        bool CheckAccount(string Account, string Password);
        string GetPassWord(string Nobr);
        bool CheckAccountSalaryPassWord(string Account, string Password);
        BaseInfoDto GetBaseInfo(string Nobr);
        BaseInfoDto GetBaseInfoAppSetting(string Nobr);
    }
}
