using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Dal.Models.HRContent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dto;

namespace JBAppService.Api.Dal.Implement.HR
{
    public class BaseHandler : IBaseHandler
    {
        private JBHRContext _context;
        static public readonly string[] EMP_HIRED_TTSCODE = new string[] { "1", "4", "6" };

        public BaseHandler(JBHRContext context)
        {
            this._context = context;
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
                DateTime DateA = DateTime.Now.Date;

                var rsBase = (from b in _context.Base
                              join bt in _context.Basetts on b.Nobr equals bt.Nobr
                              where b.Nobr.Trim() == Account && b.Password.Trim() == Password && EMP_HIRED_TTSCODE.Contains(bt.Ttscode)
                              && bt.Adate.Date <= DateA.Date && DateA.Date <= bt.Ddate.Value.Date
                              select new
                              {
                                  b.Nobr,
                                  b.Password
                              }).ToList();

                result = rsBase.Any(x => x.Nobr.Trim().ToUpper() == Account.ToUpper() && x.Password.Trim() == Password);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return result;
        }
        // GLASSNODE DATA NUPL

        /// <summary>
        /// 用薪資密碼驗證
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool CheckAccountSalaryPassWord(string Account, string Password)
        {
            Encoding encoding = new UTF8Encoding();
            bool result = false;
            try
            {
                DateTime DateA = DateTime.Now.Date;

                result = (from b in _context.Base
                          join bt in _context.Basetts on b.Nobr equals bt.Nobr
                          join password in _context.SalaryPassWord on b.Nobr equals password.SNobr
                          where b.Nobr.Trim() == Account
                          && password.SPassWord.Trim() == encoding.GetString(Convert.FromBase64String(Password))
                          && EMP_HIRED_TTSCODE.Contains(bt.Ttscode)
                          && bt.Adate <= DateA.Date && DateA.Date <= bt.Ddate
                          select new
                          {
                              b.Nobr,
                          }).Any();
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
            DateTime today = DateTime.Today;

            BaseInfoDto result = new BaseInfoDto();
            result = (from Base in _context.Base
                      join tts in _context.Basetts on Base.Nobr equals tts.Nobr
                      where Base.Nobr == Nobr
                      && tts.Adate <= today && today <= tts.Ddate
                      select new BaseInfoDto
                      {
                          Nobr = Base.Nobr,
                          Name = Base.NameC,
                          //OnLineApp = tts.OnLineApp,
                          //NoOnLineAtt = tts.NoOnLineAtt,
                      }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public BaseInfoDto GetBaseInfoAppSetting(string Nobr)
        {
            DateTime today = DateTime.Today;

            BaseInfoDto result = new BaseInfoDto();
            result = (from Base in _context.Base
                      join tts in _context.Basetts on Base.Nobr equals tts.Nobr
                      where Base.Nobr == Nobr
                      && tts.Adate <= today && today <= tts.Ddate
                      select new BaseInfoDto
                      {
                          Nobr = Base.Nobr,
                          Name = Base.NameC,
                          OnLineApp = tts.OnLineApp,
                          NoOnLineAtt = tts.NoOnLineAtt,
                      }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        public string GetPassWord(string Nobr)
        {

            string result = "";
            try
            {
                DateTime DateA = DateTime.Now.Date;

                result = (from b in _context.Base
                          where b.Nobr.Trim() == Nobr
                          select b.Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return result;
        }

        /*Wallet.Primitive.Types.UTxOIndex*/
    }
}
