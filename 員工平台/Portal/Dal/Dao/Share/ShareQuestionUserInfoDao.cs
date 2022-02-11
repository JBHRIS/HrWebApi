using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll;
using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Dal.Dao.Share;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using Bll.Tools;


namespace Dal.Dao.Share
{
    public class ShareQuestionUserInfoDao
    {

        public dcShareDataContext dcShare;

        public ShareQuestionUserInfoDao()
        {
            dcShare = new dcShareDataContext();

        }


        /// <summary>
        /// 將使用者資料記入資料庫中
        /// </summary>
        public void InsertQuestionUserInfo(string CompanyId,string UserId,string AccountCode,int RoleKey,string UserName="",string Email="",string Conetent="")
        {
            var oUserInfo = (from c in dcShare.QuestionUserInfo
                             where c.CompanyId == CompanyId && c.UserId == UserId
                             select c).FirstOrDefault();
            if (oUserInfo == null)
            {
                try 
                {
                    var rQuesitonUserInfo = new QuestionUserInfo();
                    rQuesitonUserInfo.AutoKey = 0;
                    rQuesitonUserInfo.CompanyId = CompanyId;
                    rQuesitonUserInfo.Code = Guid.NewGuid().ToString();
                    rQuesitonUserInfo.AccountCode = AccountCode;
                    rQuesitonUserInfo.UserId = UserId;
                    rQuesitonUserInfo.UserName = UserName;
                    rQuesitonUserInfo.RoleKey = RoleKey;
                    rQuesitonUserInfo.Email = Email;
                    rQuesitonUserInfo.Content = Conetent;
                    rQuesitonUserInfo.DateA = DateTime.Now;
                    rQuesitonUserInfo.DateD = DateTime.MaxValue;
                    rQuesitonUserInfo.Status = "1";
                    rQuesitonUserInfo.InsertMan = AccountCode;
                    rQuesitonUserInfo.InseetDate = DateTime.Now;
                    dcShare.QuestionUserInfo.InsertOnSubmit(rQuesitonUserInfo);
                    dcShare.SubmitChanges();
                }
                catch (Exception ex)
                { 
                
                }
                    
                
            }
            else
            {
                try
                {
                   
                    oUserInfo.CompanyId = CompanyId;
                    oUserInfo.Code = oUserInfo.Code;
                    oUserInfo.AccountCode = AccountCode;
                    oUserInfo.UserId = UserId;
                    oUserInfo.UserName = UserName;
                    oUserInfo.RoleKey = RoleKey;
                    oUserInfo.Email = Email;
                    oUserInfo.Content = Conetent;
                    oUserInfo.DateA = oUserInfo.DateA;
                    oUserInfo.DateD = oUserInfo.DateD;
                    oUserInfo.Status = "1";
                    oUserInfo.InsertMan = oUserInfo.InsertMan;
                    oUserInfo.InseetDate = oUserInfo.InseetDate;
                    oUserInfo.UpdateMan = UserName;
                    oUserInfo.UpdateTime = DateTime.Now;
                    dcShare.SubmitChanges();
                }
                catch (Exception ex)
                {

                }
               
            }
        }
    }
}
