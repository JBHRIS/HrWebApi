using Bll.Share.Vdb;
using Bll.Token.Vdb;
using Dal.Dao;
using Dal.Dao.Share;
using Dal.Dao.Token;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;

namespace Portal
{
    public partial class Login : WebPageBase
    {
        public string success { get; set; }
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
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                lblMsg.Text = "機器人驗證未通過";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CaptchaReload", "$.getScript(\"https://www.google.com/recaptcha/api.js\", function () {});", true);
                return;
            }


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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CaptchaReload", "$.getScript(\"https://www.google.com/recaptcha/api.js\", function () {});", true);
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
                        HttpContext.Current.Response.Cookies.Add(new HttpCookie("LoginMethod", "HR"));
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "CaptchaReload", "$.getScript(\"https://www.google.com/recaptcha/api.js\", function () {});", true);
                        return;
                    }
                }
                else
                {
                    lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "CaptchaReload", "$.getScript(\"https://www.google.com/recaptcha/api.js\", function () {});", true);
                    return;
                }
            }
            else
            {
                lblMsg.Text = "帳號或密碼錯誤，請重新輸入";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CaptchaReload", "$.getScript(\"https://www.google.com/recaptcha/api.js\", function () {});", true);
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
                        HttpContext.Current.Response.Cookies.Add(new HttpCookie("LoginMethod", "HR"));
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
        public bool Validate()
        {
            string Response = Request.Form["g-recaptcha-response"];//Getting Response String Append to Post Method
            bool Valid = false;
            //Request to Google Server
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create
            (" https://www.google.com/recaptcha/api/siteverify?secret=6LdzD_scAAAAADPn_JjwEiinZ_tBsBFrWFbhvAS6&response=" + Response);
            try
            {
                //Google recaptcha Response
                using (WebResponse wResponse = req.GetResponse())
                {

                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        Login data = js.Deserialize<Login>(jsonResponse);// Deserialize Json

                        Valid = Convert.ToBoolean(data.success);
                    }
                }

                return Valid;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}