using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Performance
{
    public partial class LoginFirst : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Single)Master)._DivClass = "passwordBox animated fadeInDown";

            lblMsg.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var EmpId = txtEmpId.Text;
            var Email = txtEmail.Text;

            //檢查信箱與工號是否批配
            var rEmp = (from c in dcHr.ViewEmp
                        where c.Code == EmpId && c.Email == Email
                        select c).FirstOrDefault();

            if (rEmp == null)
            {
                lblMsg.Text = "工號與信箱沒有比對成功，請檢查輸入是否正確，或洽人事單位";
                return;
            }

            var UserName = rEmp.Name;

            //先檢查User裡是否有相同的資料
            var rUser = (from c in dcShare.SystemUser
                         where c.AccountCode == EmpId
                         select c).FirstOrDefault();

            if (rUser != null)
            {
                lblMsg.Text = "該工號已經存在於系統中，請回登入頁，改按忘記密碼";
                return;
            }

            var UserCode = Guid.NewGuid().ToString();
            var AccountPassword = Security.CreateNewPassword();

            rUser = new SystemUser();
            rUser.Code = UserCode;
            rUser.AccountCode = EmpId;
            rUser.AccountPassword = AccountPassword.ToSHA512();
            rUser.MoneyPassword = AccountPassword.ToSHA512();
            rUser.RoleKey = 64;
            rUser.DateA = oMainDao._NowDate.Date;
            rUser.DateD = oMainDao._MaxDate;
            rUser.IsRegistered = false;
            rUser.Note = "";
            rUser.Status = "1";
            rUser.InsertMan = "LoginFirst";
            rUser.InsertDate = DateTime.Now;
            rUser.UpdateMan = "LoginFirst";
            rUser.UpdateDate = DateTime.Now;
            dcShare.SystemUser.InsertOnSubmit(rUser);

            var rUserInfo = new SystemUserInfo();
            rUserInfo.Code = Guid.NewGuid().ToString();
            rUserInfo.UserCode = UserCode;
            rUserInfo.UserName = UserName;
            rUserInfo.AnonymousName = UserName;
            rUserInfo.Birthday = DateTime.Now.Date;
            rUserInfo.CardId = "J180436287";
            rUserInfo.Address = "桃園市中正路1071號6樓之3";
            rUserInfo.Tel = "03-3554436";
            rUserInfo.TelA = oMainDao._NowDate.Date;
            rUserInfo.TelD = oMainDao._MaxDate;
            rUserInfo.Email = Email;
            rUserInfo.EmailA = oMainDao._NowDate.Date;
            rUserInfo.EmailD = oMainDao._MaxDate;
            rUserInfo.Sex = "1";
            rUserInfo.Note = "";
            rUserInfo.Status = "1";
            rUserInfo.InsertMan = "LoginFirst";
            rUserInfo.InsertDate = DateTime.Now;
            rUserInfo.UpdateMan = "LoginFirst";
            rUserInfo.UpdateDate = DateTime.Now;
            dcShare.SystemUserInfo.InsertOnSubmit(rUserInfo);

            var Subject = "績效獎金考核系統 首次登入 密碼通知";
            var Body = "親愛的使用者您好：<br><br>";
            Body += "您的登入密碼為：" + AccountPassword + "<br>";
            Body += "請立即登入，登入後，請記得修改密碼，謝謝。";

            var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
            var rMail = oShareDefault.DefaultMail;

            var FromAddr = "service@jbjob.com.tw";
            var FromName = "傑報管理系統";
            if (rMail != null)
            {
                FromAddr = rMail.Sender;
                FromName = rMail.SenderName;
            }

            var rShareSendQueue = new ShareSendQueue();
            rShareSendQueue.SystemCode = WebPage._SystemCode;
            rShareSendQueue.Code = Guid.NewGuid().ToString();
            rShareSendQueue.SendTypeCode = "01";
            rShareSendQueue.FromAddr = FromAddr;
            rShareSendQueue.FromName = FromName;
            rShareSendQueue.ToAddr = Email;
            rShareSendQueue.ToName = Email;
            rShareSendQueue.ToAddrCopy = "";
            rShareSendQueue.ToNameCopy = "";
            rShareSendQueue.ToAddrConfidential = "";
            rShareSendQueue.ToNameConfidential = "";
            rShareSendQueue.Subject = Subject;
            rShareSendQueue.Body = Body;
            rShareSendQueue.Retry = 0;
            rShareSendQueue.Sucess = false;
            rShareSendQueue.Suspend = false;
            rShareSendQueue.DateSend = DateTime.Now;
            rShareSendQueue.Sort = 9;
            rShareSendQueue.Note = "";
            rShareSendQueue.Status = "1";
            rShareSendQueue.InsertMan = _User.UserCode;
            rShareSendQueue.InsertDate = DateTime.Now;
            rShareSendQueue.UpdateMan = _User.UserCode;
            rShareSendQueue.UpdateDate = DateTime.Now;
            dcShare.ShareSendQueue.InsertOnSubmit(rShareSendQueue);

            dcShare.SubmitChanges();

            lblMsg.Text = "認證成功，已傳送一信到您的信箱。";
        }
    }
}