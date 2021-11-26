using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Interface._system;
using JBAppService.Api.Dal.Interface.Employee;
using JBAppService.Api.Dto;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.DirectoryServices;

namespace JBAppService.Api.Service.Implement
{
    public class BaseHandlerService : IBaseHandlerService
    {
        private IBaseHandler _IBaseHandler;

        public BaseHandlerService(IBaseHandler  baseHandler )
        {
            this._IBaseHandler = baseHandler;

        }
        public bool CheckAccount(string Account, string Password)
        {
            return this._IBaseHandler.CheckAccount(Account, Password);
        }
        public string GetPassWord(string Nobr)
        {
            return this._IBaseHandler.GetPassWord(Nobr);
        }
        public bool CheckAccountSalaryPassWord(string Account, string Password)
        {
            return _IBaseHandler.CheckAccountSalaryPassWord(Account, Password);
        }
        public BaseInfoDto GetBaseInfo(string Nobr)
        {
            return _IBaseHandler.GetBaseInfo(Nobr);
        }
        public BaseInfoDto GetBaseInfoAppSetting(string Nobr)
        {
            return _IBaseHandler.GetBaseInfoAppSetting(Nobr);
        }
    }
}
