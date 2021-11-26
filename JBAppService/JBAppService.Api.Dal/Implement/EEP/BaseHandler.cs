using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.EEPContent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dto;
using JBAppService.Api.Tool;

namespace JBAppService.Api.Dal.Implement.EEP
{
    public class BaseHandler : IBaseHandler
    {
        private JBEEPContext _content;
        public BaseHandler(JBEEPContext context)
        {
            this._content = context;
        }



        public class ActionTypeDto
        {
            public string ActionType { get; set; }
            public DateTime EffectDate { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CheckAccount(string Account, string Password)
        {

            bool result = false;
            try
            {
                DateTime today = DateTime.Today;

                //EEP 系統專用密碼解密
                char[] EncryptPassword = Password.ToArray();
                EepEncrypt.EncryptPassword(Account, Password, 10, ref EncryptPassword, true);
                var EncryptAccountPasswordEEP = string.Join("", EncryptPassword);



                var rd = (from b in _content.HRM_BASE_BASE
                          join bi in _content.HRM_BASE_BASEIO on b.EMPLOYEE_ID equals bi.EMPLOYEE_ID
                          where b.EMPLOYEE_CODE.Trim() == Account
                          && today > bi.EFFECT_DATE
                          select new
                          {
                              ActionType = bi.ACTION_TYPE,
                              EffectDate = bi.EFFECT_DATE,
                              Password = b.IDNO.Trim(),
                          }).OrderByDescending(m => m.EffectDate).FirstOrDefault();


                result = rd?.ActionType == "1" && rd?.Password == Password;
            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }

            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public BaseInfoDto GetBaseInfo(string Nobr)
        {
            BaseInfoDto result = new BaseInfoDto();

            result = (from b in _content.HRM_BASE_BASE
                      where b.EMPLOYEE_CODE == Nobr
                      select new BaseInfoDto
                      {
                          Nobr = b.EMPLOYEE_CODE,
                          Name = b.NAME_C
                      }).FirstOrDefault();

            return result;
        }

        public string GetPassWord(string Nobr)
        {
            return "";
        }

        public bool CheckAccountSalaryPassWord(string account, string password)
        {
            throw new NotImplementedException();
        }

        public BaseInfoDto GetBaseInfoAppSetting(string nobr)
        {
            throw new NotImplementedException();
        }
    }
}
