using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.JBContent;
using JBAppService.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Tool;

namespace JBAppService.Api.Dal.Implement.JB
{
    public class BaseHandler : IBaseHandler
    {

        private JBDBContent _JBDBContent;

        public BaseHandler(JBDBContent content)
        {
            this._JBDBContent = content;
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
                string password = "";

                //EEP 系統專用密碼解密
                char[] EncryptPassword = Password.ToArray();
                EepEncrypt.EncryptPassword(Account, Password, 10, ref EncryptPassword, true);
                string EncryptAccountPasswordEEP = string.Join("", EncryptPassword);

                //加密的密碼
                //var EncryptAccountPasswordSHA512 = Password.ToSHA512();

                if (EncryptAccountPasswordEEP == GetPassWord(Account))
                {
                    result = true;
                }

            }
            catch (Exception EX)
            {
                /// Password 超過10碼
                string error = EX.Message;
            }
              

            return result;
        }

        public bool CheckAccountSalaryPassWord(string account, string password)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public BaseInfoDto GetBaseInfo(string Nobr)
        {
            BaseInfoDto result = new BaseInfoDto();
            result = (from u in this._JBDBContent.USERS
                      where u.USERID == Nobr
                      select new BaseInfoDto
                      { 
                       Nobr = u.USERID,
                       Name = u.USERNAME
                       
                      }).FirstOrDefault();
            return result;
        }

        public BaseInfoDto GetBaseInfoAppSetting(string nobr)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public string GetPassWord(string Nobr)
        {
            string result = "";

            result = (from u in this._JBDBContent.USERS
                      where u.USERID == Nobr
                      select u.PWD).FirstOrDefault();

            return result;
        }
    }
}
