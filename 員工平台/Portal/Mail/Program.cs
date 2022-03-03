using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Bll.Share.Vdb;
using Dal.Dao.Share;
using System.Net.Mail;
using Dal;

namespace QuestionExpirationDateMail
{
    public class Program
    {
        public dcShareDataContext dcShare;
        static void Main(string[] args)
        {
            var oGetQuestionMain = new ShareGetQuestionMainDao();
            var GetQuestionMainCond = new ShareGetQuestionMainConditions();
           
            var result = oGetQuestionMain.GetData(GetQuestionMainCond).Data as List<ShareGetQuestionMainRow>;
            var dt = result[33].DateE.AddDays(7).Day;
            result = result.Where(x => x.DateE.Month == DateTime.Now.Month&&x.DateE.AddDays(7).Day==DateTime.Now.Day).ToList();

            List<string> Code = new List<string>();
            if (result != null)
            {
                foreach (var data in result)
                {
                    Code.Add(data.Code);
                }
                foreach (var sCode in Code)
                {

                    var oSendMail = new ShareSendQueueDao();
                    MailAddress address = new MailAddress("Aron@jbjob.com.tw");                    
                    var Subject = "";
                    var Body = "";
                    var oShareMail = new ShareMailDao();
                    var dcParameter = new Dictionary<string, string>();
                    dcParameter.Add("MainCode", sCode);
                    oShareMail.OutMailContent(out Subject, out Body, "04", 0, true, dcParameter);
                    oSendMail.SendMail(address, Subject, Body, false);
                }
            }
           


        }
    }
}
