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
            var GetQuestionMainCode = new ShareGetQuestionMainConditions();
            var result =oGetQuestionMain.GetData(GetQuestionMainCode).Data as List<ShareGetQuestionMainRow>;
            result=result.Where(x => x.DateE.AddDays(7).Day == DateTime.Now.Day ) as List<ShareGetQuestionMainRow>;
           
            List<string> Code = new List<string>();
            foreach (var data in result)
            {
                Code.Add(data.Code);
            }
            foreach (var sCode in Code)
            {
                MailAddress address = new MailAddress("aron@jbjob.com.tw");
                var oSendMail = new ShareSendQueueDao();
                var Subject = "";
                var Body = "";
                var oShareMail = new ShareMailDao();
                var dcParameter = new Dictionary<string, string>();
                dcParameter.Add("MainCode",sCode);
                oShareMail.OutMailContent(out Subject, out Body, "04", 0, true, dcParameter);
                oSendMail.SendMail(address, Subject, Body, true);
            }
            

        }
    }
}
