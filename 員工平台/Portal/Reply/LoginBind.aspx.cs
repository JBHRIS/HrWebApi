using Bll.System.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Dal.Dao.Share;
using Dal.Dao.System;
using Dal.Dao.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;

namespace Portal
{
    public partial class LoginBind : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["Param"] != null)
            {
                var Param = Request.QueryString["Param"];
                //登出
                if (Param == "Logout")
                {
                    if (Context.User.Identity.IsAuthenticated)
                    {
                        _AuthManager.SignOut();

                        Response.Redirect("LoginBind.aspx");
                    }
                }
                else//外部登入
                {
                    _AuthManager.SignOut();
                    var RequestQueryString = Security.Decrypt(Request.QueryString["Param"]);
                    var dc = DataTrans.QueryStringToDictionary(RequestQueryString);

                    ValidateBaseRedirect(dc["AccountCode"], "", true);
                }
            }
           
            if (Request.QueryString["Company"] != null)
            {
                txtCompanyId.Text = Request.QueryString["Company"];
                txtCompanyId.Visible = false;
            }

            

            ((Single)Master)._DivClass = "middle-box text-center loginscreen animated fadeInDown";
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var CompanyId = txtCompanyId.Text.Trim();
            var UserId = txtUserId.Text.Trim();
            var UserPw = txtUserPw.Text.Trim();

            if (UserId.Length == 0 || UserPw.Length == 0)
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入!";
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

            ValidateBaseRedirect(UserId, UserPw,false);
        }

        public bool ValidateBaseRedirect(string AccountCode, string AccountPassword, bool FromOutside = false,string CompanyAccountCode = "")
        {
            var Pass = false;
          
            //加密的密碼
            var EncryptAccountPasswordSHA512 = AccountPassword.ToSHA512();

            var rUser = new UserRow();
            rUser.AccountCode = AccountCode;
            rUser.AccountName = AccountCode;
            rUser.ListAccountPassword = new List<string>();
            rUser.RoleKey = 64;
            rUser.DateA = oMainDao._MinDate;
            rUser.DateD = oMainDao._MaxDate;

            //取得共同系統中的帳號資訊
            SystemUserDao oSystemUser = new SystemUserDao();
            var rSystemUser = oSystemUser.GetSystemUserValidate(AccountCode);

            if (rSystemUser != null)
            {
                rUser.ListAccountPassword.Add(rSystemUser.AccountPassword);
                rUser.RoleKey = rSystemUser.RoleKey;
                rUser.DateA = rSystemUser.DateA;
                rUser.DateD = rSystemUser.DateD;
            }

            var oShareDefault = new ShareDefaultDao();
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
                       ListAccountPassword.Contains(EncryptAccountPasswordSHA512);
            }
            if (FromOutside)
            {
                Pass = true;
            }
            //取得公司資訊
            var oShareCompany = new ShareCompanyDao();
            var CompanySetting = oShareCompany.GetCompanySetting(CompanyAccountCode);

            //向api取得驗証
            var oSignin = new SigninDao();
            var SigninCond = new SigninConditions();
            SigninCond.UserId = AccountCode;
            SigninCond.Password = AccountPassword;
            SigninCond.CompanySetting = CompanySetting;
            var Result = oSignin.GetData(SigninCond);          
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", CompanyAccountCode));
            UnobtrusiveSession.Session["CompanySetting"] = CompanySetting;
            var oClientGetToken = new ClientGetTokenDao();
            var ClientGetTokenCondition = new ClientGetTokenConditions();
            ClientGetTokenCondition.ClientId = "JbFlow";
            var ClientTokenData = oClientGetToken.GetData(ClientGetTokenCondition);
            string ClientToken = "";
            if (ClientTokenData.Status && ClientTokenData.Data != null)
            {
                var r = ClientTokenData.Data as ClientGetTokenRow;
                ClientToken = r.AccessToken;
            }
            var AccessToken = ClientToken;
            var RefreshToken = "";

            var PassApi = false;
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var rSignin = Result.Data as SigninRow;

                    if (rSignin.AccessToken.Length > 0)
                    {
                        AccessToken = rSignin.AccessToken;
                        RefreshToken = rSignin.RefreshToken;

                        PassApi = true;
                    }
                }
            }

            if (Pass||PassApi)
            {
                //超過效期
                var DateA = rUser.DateA.Date;
                var DateD = rUser.DateD.Date;
                var NowDate = oMainDao._NowDate.Date;

                if (!PassApi)
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
                oUser.EmpId = AccountCode;
                oUser.CompanyId = CompanyAccountCode;
                oUser.EmpName = rUser.AccountName;
                oUser.RoleKey = rUser.RoleKey;
                oUser.UserCode = AccountCode;
                oUser.UserPassword = AccountPassword;
                oUser.UserCodeOriginal = AccountCode;
                oUser.LoginStatus = "1";

                oUser.AccessToken = AccessToken;
                oUser.RefreshToken = RefreshToken;

                _AuthManager.SignIn(oUser, oUser.UserCode,CompanySetting,Pass);

                //撰寫歡迎訊息
                {
                    //var Code = Guid.NewGuid().ToString();

                    //var oMessageShow = oMainDao.MessageShow("0803000001");
                    //var oSystemUserNotify = new SystemUserNotifyDao();
                    //var oSystemUserNotifyInsert = new SystemUserNotifyInsertRow();
                    //oSystemUserNotifyInsert.IpAddress = WebPage.GetClientIP(Context);
                    //oSystemUserNotifyInsert.AppName = Request.Url.ToString();
                    //oSystemUserNotifyInsert.InsertMan = _User.UserCode;
                    //oSystemUserNotifyInsert.ListSystemUserNotify = new List<SystemUserNotifyRow>();
                    //var rSystemUserNotify = new SystemUserNotifyRow();
                    //rSystemUserNotify.Code = Code;
                    //rSystemUserNotify.UserCode = UserCodeNew;
                    //rSystemUserNotify.UserCodeSend = "01";
                    //rSystemUserNotify.UserName = "系統管理者";
                    //rSystemUserNotify.NotifyTypeCode = "01";
                    //rSystemUserNotify.AppName = "Login";
                    //rSystemUserNotify.AppCode = UserCodeNew;
                    //rSystemUserNotify.TitleContents = oMessageShow?.TitleContents ?? "歡迎回來";
                    //rSystemUserNotify.Contents = oMessageShow?.Contents ?? "今天簽到了嗎？";
                    //rSystemUserNotify.IsRead = false;
                    //rSystemUserNotify.DateA = DateTime.Now.Date;
                    //rSystemUserNotify.DateD = DateTime.Now.Date;
                    //oSystemUserNotifyInsert.ListSystemUserNotify.Add(rSystemUserNotify);
                    //oSystemUserNotify.SystemUserNotifyInsert(oSystemUserNotifyInsert);
                }

                if (UnobtrusiveSession.Session["ReturnUrl"] != null)
                {
                    var ReturnUrl = UnobtrusiveSession.Session["ReturnUrl"].ToString();
                    UnobtrusiveSession.Session["ReturnUrl"] = null;
                    Response.Redirect(ReturnUrl);
                }
                if (FromOutside)
                {
                    var RequestQueryString = Security.Decrypt(Request.QueryString["Param"]);
                    var dc = DataTrans.QueryStringToDictionary(RequestQueryString);
                    Response.Redirect("ProblemReturnView.aspx?Code=" + dc["Code"], true);
                }
                Response.Redirect("ProblemReturn.aspx", false);
            }
            else
            {
                var oMessageShow = oMainDao.MessageShow("0903000001");
                lblMsg.Text = oMessageShow?.Contents ?? "帳號或密碼錯誤，請重新輸入";
            }

            return Pass;
        }

        //protected void btnOAuth2Login_Click(object sender, EventArgs e)
        //{
        //    var CommandName = ((RadButton)sender).CommandName;

        //    //已經登入的狀態 就不允許登入
        //    if (_User.LoginStatus == "1")
        //    {
        //        _AuthManager.SignOut();
        //        //var oMessageShow = oMainDao.MessageShow("0903000009");
        //        //lblMsg.Text = oMessageShow?.Contents ?? "目前是登入狀態，請先登出，如果您要綁定，請到個人帳號進行綁定";
        //        //return;
        //    }

        //    var loginWith = CommandName;
        //    var scope = "";
        //    var state = Guid.NewGuid().ToString();
        //    var redirect_uri = "";
        //    var clientId = "";
        //    var AuthUrl = "";

        //    switch (CommandName)
        //    {
        //        case "Google":
        //            {
        //                UnobtrusiveSession.Session["DefaultOAuth2Google"] = null;
        //                var DefaultOAuth2 = AccessData.DefaultOAuth2Google;

        //                scope = DefaultOAuth2.Scope;
        //                state = Guid.NewGuid().ToString();
        //                redirect_uri = HttpUtility.UrlEncode(DefaultOAuth2.RedirectUrl);
        //                clientId = DefaultOAuth2.ClientId;
        //                AuthUrl = DefaultOAuth2.AuthUrl;
        //            }
        //            break;
        //        case "Facebook":
        //            {
        //                UnobtrusiveSession.Session["DefaultOAuth2Facebook"] = null;
        //                var DefaultOAuth2 = AccessData.DefaultOAuth2Facebook;

        //                scope = DefaultOAuth2.Scope;
        //                state = Guid.NewGuid().ToString();
        //                redirect_uri = HttpUtility.UrlEncode(DefaultOAuth2.RedirectUrl);
        //                clientId = DefaultOAuth2.ClientId;
        //                AuthUrl = DefaultOAuth2.AuthUrl;
        //            }
        //            break;
        //        case "Line":
        //            {
        //                UnobtrusiveSession.Session["DefaultOAuth2Line"] = null;
        //                var DefaultOAuth2 = AccessData.DefaultOAuth2Line;

        //                scope = DefaultOAuth2.Scope;
        //                state = Guid.NewGuid().ToString();
        //                redirect_uri = HttpUtility.UrlEncode(DefaultOAuth2.RedirectUrl);
        //                clientId = DefaultOAuth2.ClientId;
        //                AuthUrl = DefaultOAuth2.AuthUrl;
        //            }
        //            break;
        //    }

        //    var Url = $"{AuthUrl}?scope={scope}&state={state}&redirect_uri={redirect_uri}&response_type=code&client_id={clientId}&approval_prompt=force";

        //    UnobtrusiveSession.Session["state"] = state;
        //    UnobtrusiveSession.Session["loginWith"] = loginWith;
        //    Response.Redirect(Url);
        //}
    }
}