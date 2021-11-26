using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IBaseHandler
    {
        bool CheckAccount(string Account, string Password);

        BaseInfoDto GetBaseInfo(string Nobr);


        string  GetPassWord(string Nobr);
        bool CheckAccountSalaryPassWord(string account, string password);
        BaseInfoDto GetBaseInfoAppSetting(string nobr);
    }
}
