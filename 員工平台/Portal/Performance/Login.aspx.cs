using Bll.System.Vdb;
using Bll.Tools;
using Dal.Dao.Share;
using Dal.Dao.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class Login : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //登出
            if (Request.QueryString["Param"] != null)
            {
                var Param = Request.QueryString["Param"];
                if (Param == "Logout")
                {
                    if (Context.User.Identity.IsAuthenticated)
                    {
                        _AuthManager.SignOut();

                        Response.Redirect("Login.aspx");
                    }
                }
            }

            ((Single)Master)._DivClass = "middle-box text-center loginscreen animated fadeInDown";
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var UserId = txtUserId.Text.Trim();
            var UserPw = txtUserPw.Text.Trim();

            if (UserId.Length == 0 || UserPw.Length == 0)
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入1";
                return;
            }

            ValidateBaseRedirect(UserId, UserPw);
        }

        protected void btnSpeedLogin_Click(object sender, EventArgs e)
        {
            var btn = ((RadButton)sender);
            //btn.CommandName;
            //btn.CommandArgument;

            var UserId = btn.CommandName;
            var UserPw = btn.CommandArgument;

            if (UserId.Length == 0 || UserPw.Length == 0)
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入1";
                return;
            }

            ValidateBaseRedirect(UserId, UserPw);
        }

        public bool ValidateRedirect(string AccountCode, string AccountPassword)
        {
            var Pass = false;

            if (!ValidateBaseRedirect(AccountCode, AccountPassword))
            {
                SystemUserDao oSystemUser = new SystemUserDao(WebPage.dcShare);
                var rSystemUser = oSystemUser.GetSystemUserValidate(AccountCode, AccountPassword);

                if (rSystemUser != null)
                {
                    //超過效期
                    var DateA = rSystemUser.DateA.Date;
                    var DateD = rSystemUser.DateD.Date;
                    var NowDate = oMainDao._NowDate.Date;

                    if (DateA > NowDate || DateD < NowDate)
                    {
                        var oMessageShow = oMainDao.MessageShow("0903000002");
                        lblMsg.Text = oMessageShow?.Contents ?? "您的帳號異常或超過使用效期";
                        return Pass;
                    }

                    var UserCodeOld = _User.UserCode;
                    var UserCodeNew = rSystemUser.Code;
                    var RoleKey = rSystemUser.RoleKey;

                    var oUser = new User();
                    oUser.EmpName = AccountCode;
                    oUser.RoleKey = RoleKey;
                    oUser.UserCode = AccountCode;
                    oUser.UserCodeOriginal = AccountCode;
                    oUser.LoginStatus = "1";

                    _AuthManager.SignIn(oUser, UserCodeOld);

                    //撰寫歡迎訊息
                    {
                        var Code = Guid.NewGuid().ToString();

                        var oMessageShow = oMainDao.MessageShow("0803000001");
                        var oSystemUserNotify = new SystemUserNotifyDao(WebPage.dcShare);
                        var oSystemUserNotifyInsert = new SystemUserNotifyInsertRow();
                        oSystemUserNotifyInsert.IpAddress = WebPage.GetClientIP(Context);
                        oSystemUserNotifyInsert.AppName = Request.Url.ToString();
                        oSystemUserNotifyInsert.InsertMan = _User.UserCode;
                        oSystemUserNotifyInsert.ListSystemUserNotify = new List<SystemUserNotifyRow>();
                        var rSystemUserNotify = new SystemUserNotifyRow();
                        rSystemUserNotify.Code = Code;
                        rSystemUserNotify.UserCode = UserCodeNew;
                        rSystemUserNotify.UserCodeSend = "01";
                        rSystemUserNotify.UserName = "系統管理者";
                        rSystemUserNotify.NotifyTypeCode = "01";
                        rSystemUserNotify.AppName = "Login";
                        rSystemUserNotify.AppCode = UserCodeNew;
                        rSystemUserNotify.TitleContents = oMessageShow?.TitleContents ?? "歡迎回來";
                        rSystemUserNotify.Contents = oMessageShow?.Contents ?? "目前本網站試營運中";
                        rSystemUserNotify.IsRead = false;
                        rSystemUserNotify.DateA = DateTime.Now.Date;
                        rSystemUserNotify.DateD = DateTime.Now.Date;
                        oSystemUserNotifyInsert.ListSystemUserNotify.Add(rSystemUserNotify);
                        oSystemUserNotify.SystemUserNotifyInsert(oSystemUserNotifyInsert);
                    }

                    Pass = true;

                    if (UnobtrusiveSession.Session["ReturnUrl"] != null)
                    {
                        var ReturnUrl = UnobtrusiveSession.Session["ReturnUrl"].ToString();
                        UnobtrusiveSession.Session["ReturnUrl"] = null;
                        Response.Redirect(ReturnUrl);
                    }

                    Response.Redirect("Index.aspx", false);
                }
                else
                {
                    var oMessageShow = oMainDao.MessageShow("0903000001");
                    lblMsg.Text = oMessageShow?.Contents ?? "帳號或密碼錯誤，請重新輸入";
                }
            }

            return Pass;
        }

        public bool ValidateBaseRedirect(string AccountCode, string AccountPassword)
        {
            var Pass = false;

            //EEP 系統專用密碼解密
            char[] EncryptPassword = AccountPassword.ToArray();
            EepEncrypt.EncryptPassword(AccountCode, AccountPassword, 10, ref EncryptPassword, true);
            var EncryptAccountPasswordEEP = string.Join("", EncryptPassword);

            //加密的密碼
            var EncryptAccountPasswordSHA512 = AccountPassword.ToSHA512();

            var rUser = new UserRow();
            rUser.AccountCode = AccountCode;
            rUser.AccountName = AccountCode;
            rUser.ListAccountPassword = new List<string>();
            rUser.RoleKey = 64;
            rUser.DateA = oMainDao._MinDate;
            rUser.DateD = oMainDao._MaxDate;

            //取得HR系統的帳號資訊
            var rEmp = (from c in dcHr.ViewEmp
                        where c.Code == AccountCode
                        //where c.Code == AccountCode && (c.Password == EncryptAccountPassword || UniversalPassword == AccountPassword)
                        select c).FirstOrDefault();

            if (rEmp != null)
            {
                rUser.ListAccountPassword.Add(rEmp.Password);
                rUser.AccountName = rEmp.Name;
            }

            //取得共同系統中的帳號資訊
            SystemUserDao oSystemUser = new SystemUserDao(WebPage.dcShare);
            var rSystemUser = oSystemUser.GetSystemUserValidate(AccountCode);

            if (rSystemUser != null)
            {
                rUser.ListAccountPassword.Add(rSystemUser.AccountPassword);
                rUser.RoleKey = rSystemUser.RoleKey;
                rUser.DateA = rSystemUser.DateA;
                rUser.DateD = rSystemUser.DateD;
            }

            var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
            var rSystem = oShareDefault.DefaultSystem;
            var UniversalAccountCode = rSystem.UniversalAccountCode;
            var UniversalAccountPassword = rSystem.UniversalAccountPassword;

            //加密萬用密碼
            rUser.ListAccountPassword.Add(UniversalAccountPassword);

            //萬用帳號及密碼吻合 直接給予最高權限 及 最大效期
            if (UniversalAccountCode == AccountCode && (UniversalAccountPassword == AccountPassword || UniversalAccountPassword == EncryptAccountPasswordSHA512))
            {
                rUser.RoleKey = 2;
                rUser.DateA = rSystemUser.DateA;
                rUser.DateD = rSystemUser.DateD;

                Pass = true;
            }
            else
            {
                //三種方式都可以通過
                //1.直接使用萬用帳號及密碼通過
                //2.真實的帳號配合一組可用的密碼(HR系統、共用系統、萬用密碼)
                //3.真實的帳號配合一組可用的加密密碼(HR系統、共用系統、萬用密碼)

                var ListAccountPassword = rUser.ListAccountPassword;
                Pass = ListAccountPassword.Contains(AccountPassword) ||
                       ListAccountPassword.Contains(EncryptAccountPasswordSHA512) ||
                       ListAccountPassword.Contains(EncryptAccountPasswordEEP);
            }

            if (Pass)
            {
                //超過效期
                var DateA = rUser.DateA.Date;
                var DateD = rUser.DateD.Date;
                var NowDate = oMainDao._NowDate.Date;

                if (DateA > NowDate || DateD < NowDate)
                {
                    var oMessageShow = oMainDao.MessageShow("0903000002");
                    lblMsg.Text = oMessageShow?.Contents ?? "您的帳號異常或超過使用效期";
                    return false;
                }

                var UserCodeOld = _User.UserCode;
                var UserCodeNew = AccountCode;

                //暫時換人
                //AccountCode = "000008";

                var oUser = new User();
                oUser.EmpName = rUser.AccountName;
                oUser.RoleKey = rUser.RoleKey;
                oUser.UserCode = AccountCode;
                oUser.UserCodeOriginal = AccountCode;
                oUser.LoginStatus = "1";

                _AuthManager.SignIn(oUser, UserCodeOld);

                //撰寫歡迎訊息
                {
                    var Code = Guid.NewGuid().ToString();

                    var oMessageShow = oMainDao.MessageShow("0803000001");
                    var oSystemUserNotify = new SystemUserNotifyDao(WebPage.dcShare);
                    var oSystemUserNotifyInsert = new SystemUserNotifyInsertRow();
                    oSystemUserNotifyInsert.IpAddress = WebPage.GetClientIP(Context);
                    oSystemUserNotifyInsert.AppName = Request.Url.ToString();
                    oSystemUserNotifyInsert.InsertMan = _User.UserCode;
                    oSystemUserNotifyInsert.ListSystemUserNotify = new List<SystemUserNotifyRow>();
                    var rSystemUserNotify = new SystemUserNotifyRow();
                    rSystemUserNotify.Code = Code;
                    rSystemUserNotify.UserCode = UserCodeNew;
                    rSystemUserNotify.UserCodeSend = "01";
                    rSystemUserNotify.UserName = "系統管理者";
                    rSystemUserNotify.NotifyTypeCode = "01";
                    rSystemUserNotify.AppName = "Login";
                    rSystemUserNotify.AppCode = UserCodeNew;
                    rSystemUserNotify.TitleContents = oMessageShow?.TitleContents ?? "歡迎回來";
                    rSystemUserNotify.Contents = oMessageShow?.Contents ?? "目前本網站試營運中";
                    rSystemUserNotify.IsRead = false;
                    rSystemUserNotify.DateA = DateTime.Now.Date;
                    rSystemUserNotify.DateD = DateTime.Now.Date;
                    oSystemUserNotifyInsert.ListSystemUserNotify.Add(rSystemUserNotify);
                    oSystemUserNotify.SystemUserNotifyInsert(oSystemUserNotifyInsert);
                }

                if (UnobtrusiveSession.Session["ReturnUrl"] != null)
                {
                    var ReturnUrl = UnobtrusiveSession.Session["ReturnUrl"].ToString();
                    UnobtrusiveSession.Session["ReturnUrl"] = null;
                    Response.Redirect(ReturnUrl);
                }

                Response.Redirect("Index.aspx", false);
            }
            else
            {
                var oMessageShow = oMainDao.MessageShow("0903000001");
                lblMsg.Text = oMessageShow?.Contents ?? "帳號或密碼錯誤，請重新輸入";
            }

            return Pass;
        }
    }
}