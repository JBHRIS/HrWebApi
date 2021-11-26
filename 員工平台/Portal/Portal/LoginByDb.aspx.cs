using Bll.System.Vdb;
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

namespace Portal
{
    public partial class LoginByDb : WebPageBase
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

                        Response.Redirect("LoginByDb.aspx");
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

            ValidateRedirect(UserId, UserPw);
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

            ValidateRedirect(UserId, UserPw);
        }

        public bool ValidateRedirect(string AccountCode, string AccountPassword)
        {
            var Pass = false;

            //if (!ValidateBaseRedirect(AccountCode, AccountPassword))
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

                    _AuthManager.SignInByDb(oUser, UserCodeOld,CompanySetting);

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

                    Response.Redirect("AppCoordinate.aspx", false);
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

            var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
            var rSystem = oShareDefault.DefaultSystem;
            var UniversalPassword = rSystem.UniversalAccountPassword;

            var rEmp = (from c in dcHr.ViewEmp
                        where c.Code == AccountCode && (c.Password == AccountPassword || UniversalPassword == AccountPassword)
                        select c).FirstOrDefault();

            if (rEmp != null)
            {
                var UserCodeOld = _User.UserCode;
                var UserCodeNew = rEmp.Code;

                //暫時換人
                //AccountCode = "000008";

                var oUser = new User();
                oUser.EmpName = rEmp.Name;
                oUser.RoleKey = 64;
                oUser.UserCode = AccountCode;
                oUser.UserCodeOriginal = AccountCode;
                oUser.LoginStatus = "1";

                _AuthManager.SignIn(oUser, UserCodeOld,CompanySetting);


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

                Response.Redirect("AppQRCode.aspx", false);
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