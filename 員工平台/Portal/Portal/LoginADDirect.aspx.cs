using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Dal.Dao;
using Dal.Dao.Share;
using Dal.Dao.Token;
using System.DirectoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using System.Text;
using System.Text.RegularExpressions;
using Bll.Tools;

namespace Portal
{
    public partial class LoginADDirect : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveSession.Session["LoginMethod"] = null;
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("LoginMethod", "AD"));
            //登出
            if (Request.QueryString["Param"] != null)
            {
                var Param = Request.QueryString["Param"];
                if (Param == "Logout")
                {
                    if (Context.User.Identity.IsAuthenticated)
                    {
                        _AuthManager.SignOut();

                        Response.Redirect("LoginADDirect.aspx");
                    }
                }
            }

            if (Request.QueryString["Company"] != null)
            {
                txtCompanyId.Text = Request.QueryString["Company"];
                txtCompanyId.Visible = false;

                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(txtCompanyId.Text);

                if (CompanySetting.FileNameLoginPage != null)
                    LoginIcon.ImageUrl = CompanySetting.FileNameLoginPage;

                this.CompanySetting = CompanySetting;
                var oConnection = new ConnectionDao();
                var ConnectionCondition = new ConnectionConditions();
                ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                var LoginTokenResult = oConnection.GetData(ConnectionCondition);

                LoginToken = LoginTokenResult.Payload.ToString();
                UnobtrusiveSession.Session["ConnectionToken"] = LoginToken;
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", txtCompanyId.Text));
                UnobtrusiveSession.Session["CompanySetting"] = CompanySetting;
            }

            else if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
            {
                txtCompanyId.Text = Request.Cookies["CompanyId"].Value;
                txtCompanyId.Visible = false;

                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(txtCompanyId.Text);

                LoginIcon.ImageUrl = CompanySetting.FileNameLoginPage;

                this.CompanySetting = CompanySetting;
                var oConnection = new ConnectionDao();
                var ConnectionCondition = new ConnectionConditions();
                ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                var LoginTokenResult = oConnection.GetData(ConnectionCondition);

                LoginToken = LoginTokenResult.Payload.ToString();
                UnobtrusiveSession.Session["ConnectionToken"] = LoginToken;

                HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", txtCompanyId.Text));
                UnobtrusiveSession.Session["CompanySetting"] = CompanySetting;
            }
            ((Single)Master)._DivClass = "middle-box text-center loginscreen animated fadeInDown";
            var oEncryptHepler = new EncryptHepler();
            string AdSite = System.Web.Configuration.WebConfigurationManager.AppSettings["AdSite"];
            if (Request["auth"] != null && Request["auth"].ToString().Trim().Length == 0)
            {
                Response.Redirect("Login.aspx?param=Logout");
                return;
            }
            else if (Request["auth"] != null)
            {
                string AdName = "";
                string str = oEncryptHepler.Decrypt(Request["auth"]);
                string[] strArr = Regex.Split(str, EncryptHepler.pwdValue);
                if (strArr.Length > 0)
                    AdName = strArr[0];
                if (AdName.Trim().Length == 0)
                {
                    Response.Redirect("Login.aspx?param=Logout");
                    return;
                }
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
                var oAdSignin = new AdSigninDao();
                var AdSigninCond = new AdSigninConditions();
                AdSigninCond.AccessToken = ClientToken;
                AdSigninCond.AdName = AdName;
                var AdSigninResult = oAdSignin.GetData(AdSigninCond);
                //向api取得驗証
                //var oSignin = new SigninDao();
                //var SigninCond = new SigninConditions();
                //SigninCond.AccessToken = LoginToken;
                //SigninCond.UserId = UserId;
                //SigninCond.Password = UserPw;
                //SigninCond.CompanySetting = CompanySetting;
                //var Result = oSignin.GetData(SigninCond);

                if (AdSigninResult.Status)
                {
                    if (AdSigninResult.Data != null)
                    {
                        var rSignin = AdSigninResult.Data as AdSigninRow;

                        if (rSignin.AccessToken.Length > 0)
                        {
                            var oUser = new User();
                            oUser.UserCode = AdName;
                            oUser.UserCodeOriginal = AdName;
                            oUser.AccessToken = rSignin.AccessToken;
                            oUser.RefreshToken = rSignin.RefreshToken;
                            oUser.LoginStatus = "1";

                            oUser.EmpId = AdName;

                            var UserCodeOld = _User.UserCode;

                            _AuthManager.SignIn(oUser, UserCodeOld, CompanySetting);
                            var ReturnUrl = "Index.aspx";
                            Response.Redirect(ReturnUrl);

                        }
                        else
                        {
                            lblMsg.Text = "帳號或密碼錯誤，請重新輸入(Token Empty)";
                            return;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "無對應的AD帳號，請確認資料是否正確";
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = "無對應的AD帳號，請確認資料是否正確";
                    return;
                }

            }
            else
                Response.Redirect(AdSite + @"?S=" + Server.UrlEncode(oEncryptHepler.Encrypt(Request.Url.AbsoluteUri)));
        }

        public DirectoryEntry GetLdapData(string username, string password)
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://" + System.Configuration.ConfigurationManager.AppSettings["AdServer"], username, password);



            return de;
        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var Contents = "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo();
            var SystemContents = "開始登入" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
            var AppName = Request.Url.ToString();
            var Ip = WebPage.GetClientIP(Context);
            oMainDao.MessageLog("3", Contents, SystemContents, AppName, Ip, _User.UserCode);

            var CompanyId = txtCompanyId.Text.Trim();
            var UserId = txtUserId.Text.Trim();
            var UserPw = txtUserPw.Text.Trim();

            if (UserId.Length == 0 || UserPw.Length == 0)
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                return;
            }

            var ReturnUrl = "Index.aspx";

            //取得公司資訊
            if (UnobtrusiveSession.Session["CompanySetting"] != null)
            {
                var CompanySstting = UnobtrusiveSession.Session["CompanySetting"] as CompanySettingRow;
                this.CompanySetting = CompanySstting;
            }
            else if (CompanyId != "")
            {
                var oShareCompany = new ShareCompanyDao();
                this.CompanySetting = oShareCompany.GetCompanySetting(CompanyId);
            }

            //if (CompanySetting == null)
            //{
            //    lblMsg.Text = "公司代碼(統編)錯誤";
            //    return;
            //}
            if (CompanySetting != null)
            {
                var oConnection = new ConnectionDao();
                var ConnectionCondition = new ConnectionConditions();
                ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                ConnectionCondition.CompanySetting = CompanySetting;
                var LoginTokenResult = oConnection.GetData(ConnectionCondition);
                LoginToken = LoginTokenResult.Payload.ToString();
            }
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", CompanyId));

            SystemContents = "開始呼叫登入HrApi" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
            oMainDao.MessageLog("3", Contents, SystemContents, AppName, Ip, _User.UserCode);
            UnobtrusiveSession.Session["ConnectionToken"] = LoginToken;
            string AdName = "";
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
            var LdapData = GetLdapData(UserId, UserPw);
            try
            {
                AdName = LdapData.Name.Substring(3) + "\\" + LdapData.Username;
            }
            catch (Exception)
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                return;
            }


            var oAdSignin = new AdSigninDao();
            var AdSigninCond = new AdSigninConditions();
            AdSigninCond.AccessToken = ClientToken;
            AdSigninCond.AdName = AdName;
            var AdSigninResult = oAdSignin.GetData(AdSigninCond);
            //向api取得驗証
            //var oSignin = new SigninDao();
            //var SigninCond = new SigninConditions();
            //SigninCond.AccessToken = LoginToken;
            //SigninCond.UserId = UserId;
            //SigninCond.Password = UserPw;
            //SigninCond.CompanySetting = CompanySetting;
            //var Result = oSignin.GetData(SigninCond);

            if (AdSigninResult.Status)
            {
                if (AdSigninResult.Data != null)
                {
                    var rSignin = AdSigninResult.Data as AdSigninRow;

                    if (rSignin.AccessToken.Length > 0)
                    {
                        var oUser = new User();
                        oUser.UserCode = UserId;
                        oUser.UserCodeOriginal = UserId;
                        oUser.AccessToken = rSignin.AccessToken;
                        oUser.RefreshToken = rSignin.RefreshToken;
                        oUser.LoginStatus = "1";

                        oUser.EmpId = UserId;

                        var UserCodeOld = _User.UserCode;

                        if (UnobtrusiveSession.Session["ReturnUrl"] != null)
                            ReturnUrl = (string)UnobtrusiveSession.Session["ReturnUrl"];

                        _AuthManager.SignIn(oUser, UserCodeOld, CompanySetting);
                        SystemContents = "結束登入" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
                        oMainDao.MessageLog("3", Contents, SystemContents, AppName, Ip, _User.UserCode);
                        Response.Redirect(ReturnUrl);
                    }
                    else
                    {
                        lblMsg.Text = "帳號或密碼錯誤，請重新輸入(Token Empty)";
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                    return;
                }
            }
            else
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                return;
            }

        }

        protected void btnSpeedLogin_Click(object sender, EventArgs e)
        {
            var Contents = "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo();
            var SystemContents = "開始登入" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
            var AppName = Request.Url.ToString();
            var Ip = WebPage.GetClientIP(Context);
            oMainDao.MessageLog("3", Contents, SystemContents, AppName, Ip, _User.UserCode);
            var btn = ((RadButton)sender);
            //btn.CommandName;
            //btn.CommandArgument;

            var UserId = btn.CommandName;
            var UserPw = btn.CommandArgument;

            if (UserId.Length == 0 || UserPw.Length == 0)
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                return;
            }

            var ReturnUrl = "Index.aspx";

            //取得公司資訊
            var oShareCompany = new ShareCompanyDao();
            var CompanySetting = oShareCompany.GetCompanySetting("demo");

            //if (CompanySetting == null)
            //{
            //    lblMsg.Text = "公司代碼(統編)錯誤";
            //    return;
            //}
            var oConnection = new ConnectionDao();
            var ConnectionCondition = new ConnectionConditions();
            ConnectionCondition.DbName = CompanySetting.HrApiConnection;
            var LoginTokenResult = oConnection.GetData(ConnectionCondition);
            LoginToken = LoginTokenResult.Payload.ToString();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", "demo"));

            SystemContents = "開始呼叫登入HrWebApi" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
            oMainDao.MessageLog("3", Contents, SystemContents, AppName, Ip, _User.UserCode);

            UnobtrusiveSession.Session["ConnectionToken"] = LoginToken;
            //向api取得驗証
            var oSignin = new SigninDao();
            var SigninCond = new SigninConditions();
            SigninCond.AccessToken = LoginToken;
            SigninCond.UserId = UserId;
            SigninCond.Password = UserPw;
            SigninCond.CompanySetting = CompanySetting;
            var Result = oSignin.GetData(SigninCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var rSignin = Result.Data as SigninRow;

                    if (rSignin.AccessToken.Length > 0)
                    {
                        var oUser = new User();
                        oUser.UserCode = UserId;
                        oUser.UserCodeOriginal = UserId;
                        oUser.AccessToken = rSignin.AccessToken;
                        oUser.RefreshToken = rSignin.RefreshToken;
                        oUser.LoginStatus = "1";

                        oUser.EmpId = UserId;

                        var UserCodeOld = _User.UserCode;

                        if (UnobtrusiveSession.Session["ReturnUrl"] != null)
                            ReturnUrl = (string)UnobtrusiveSession.Session["ReturnUrl"];

                        _AuthManager.SignIn(oUser, UserCodeOld, CompanySetting);
                        SystemContents = "結束登入" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
                        oMainDao.MessageLog("3", Contents, SystemContents, AppName, Ip, _User.UserCode);
                        Response.Redirect(ReturnUrl);
                    }
                    else
                    {
                        lblMsg.Text = "帳號或密碼錯誤，請重新輸入(Token Empty)";
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                    return;
                }
            }
            else
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                return;
            }


        }
    }
}