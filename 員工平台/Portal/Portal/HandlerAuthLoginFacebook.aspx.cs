using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Dal.Dao;
using Dal.Dao.Share;
using Dal.Dao.System;
using Dal.Dao.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Portal
{
    public partial class HandlerAuthLoginFacebook : WebPageBase
    {
        protected string ThirdPartyTypeCode = "Facebook";

        protected string client_id = "";    // Replace this with your Client ID
        protected string client_secret = "";// Replace this with your Client Secret
        protected string redirect_url = ""; // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        protected string Parameters;

        public string ReturnUrl = "LoginBind.aspx";

        DefaultOAuth2FacebookRow DefaultOAuth2 = AccessData.DefaultOAuth2Facebook;

        protected async void Page_Load(object sender, EventArgs e)
        {
            client_id = DefaultOAuth2.ClientId;
            client_secret = DefaultOAuth2.ClientSecret;
            redirect_url = HttpUtility.UrlEncode(DefaultOAuth2.RedirectUrl);
            var TokenUrl = DefaultOAuth2.TokenUrl;

            if ((UnobtrusiveSession.Session["loginWith"] != null) && (UnobtrusiveSession.Session["state"] != null) && (UnobtrusiveSession.Session["loginWith"].ToString() == ThirdPartyTypeCode))
            {
                try
                {
                    var url = Request.Url.Query;
                    if (url != "")
                    {
                        //string queryString = url.ToString();
                        //char[] delimiterChars = { '=' };
                        //string[] words = queryString.Split(delimiterChars);
                        //string code = words[1];
                        var code = Request.QueryString["code"];
                        var state = Request.QueryString["state"];

                        var stateOrginal = UnobtrusiveSession.Session["state"];

                        //權杖必須相同
                        if (stateOrginal.Equals(state))
                            if (code != null)
                            {
                                //get the access token 
                                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(TokenUrl);
                                webRequest.Method = "POST";
                                Parameters = "code=" + code + "&client_id=" + client_id + "&client_secret=" + client_secret + "&redirect_uri=" + redirect_url + "&grant_type=authorization_code";
                                byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
                                webRequest.ContentType = "application/x-www-form-urlencoded";
                                webRequest.ContentLength = byteArray.Length;
                                Stream postStream = webRequest.GetRequestStream();
                                // Add the post data to the web request
                                postStream.Write(byteArray, 0, byteArray.Length);
                                postStream.Close();

                                WebResponse response = webRequest.GetResponse();
                                postStream = response.GetResponseStream();
                                StreamReader reader = new StreamReader(postStream);
                                string responseFromServer = reader.ReadToEnd();

                                var serStatus = JsonConvert.DeserializeObject<AccessToken>(responseFromServer);

                                if (serStatus != null)
                                {
                                    string accessToken = string.Empty;
                                    accessToken = serStatus.access_token;

                                    if (!string.IsNullOrEmpty(accessToken))
                                    {
                                        if (UnobtrusiveSession.Session["ReturnUrl"] != null)
                                        {
                                            ReturnUrl = UnobtrusiveSession.Session["ReturnUrl"].ToString();
                                            UnobtrusiveSession.Session["ReturnUrl"] = null;
                                        }

                                        // This is where you want to add the code if login is successful.
                                        await getuserdataSer(accessToken);

                                        ReturnUrl = "Index.aspx";
                                    }
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                    oMainDao.MessageLog("3", "系統錯誤", ex.ToString(), Request.Url.ToString(), WebPage.GetClientIP(Context), _User.UserCode);
                    ReturnUrl = "LoginBind.aspx";
                }
            }

            Response.Redirect(ReturnUrl);
            if (!Response.IsRequestBeingRedirected)
                Response.Redirect(ReturnUrl);
        }

        private async Task getuserdataSer(string access_token)
        {
            try
            {
                var UserInfoUrl = DefaultOAuth2.UserInfoUrl;

                HttpClient client = new HttpClient();
                var urlProfile = UserInfoUrl + "?access_token=" + access_token;

                client.CancelPendingRequests();
                HttpResponseMessage output = await client.GetAsync(urlProfile);

                if (output.IsSuccessStatusCode)
                {

                    string outputData = await output.Content.ReadAsStringAsync();

                    var serStatus = JsonConvert.DeserializeObject<UserOutputData>(outputData);

                    if (serStatus != null)
                    {
                        var ThirdPartyAccountId = serStatus.id;
                        var Email = serStatus.email;
                        var AnonymousName = serStatus.given_name;
                        var UserName = serStatus.name;
                        AnonymousName = AnonymousName.Length > 0 ? AnonymousName : UserName;
                        var AccountCode = ThirdPartyTypeCode + "-" + ThirdPartyAccountId;
                        var PictureUrl = serStatus.picture; //縮圖

                        //判斷帳號是否有綁定 無綁定才需要儲存
                        //判斷綁定信箱是否被註冊過
                        var oSystemUserAccountBind = new SystemUserAccountBindDao();
                        var SystemUserAccountBindCond = new SystemUserAccountBindConditions();
                        var SystemUserAccountBindUserCode = "";
                        SystemUserAccountBindCond.ThirdPartyTypeCode = ThirdPartyTypeCode;
                        SystemUserAccountBindCond.ThirdPartyAccountId = ThirdPartyAccountId;
                        var rSystemUserAccountBind = oSystemUserAccountBind.GetSystemUserAccountBind(SystemUserAccountBindCond).FirstOrDefault();
                        if (rSystemUserAccountBind != null)
                            SystemUserAccountBindUserCode = rSystemUserAccountBind.UserCode;

                        var UserCode = _User.UserCode;
                        var UserCodeOld = UserCode;
                        var RoleKey = 64;

                        var oSystemUser = new SystemUserDao();

                        //有綁定過 導向綁定的id                           
                        UserCode = SystemUserAccountBindUserCode;
                        var UserCodeOriginal = UserCode;

                        //取得權限資訊
                        var SystemUserCond = new SystemUserConditions();
                        SystemUserCond.Code = UserCode;
                        var rSystemUser = oSystemUser.GetSystemUser(SystemUserCond).FirstOrDefault();

                        if (rSystemUser == null)
                        {
                            ReturnUrl = "LoginBind.aspx";
                            UnobtrusiveSession.Session["LoginPass"] = "0";
                        }
                        else
                        {
                            var CompanyId = rSystemUser.CompnayId;
                            RoleKey = rSystemUser.RoleKey;
                            var UserId = rSystemUser.AccountCode;
                            var AccountPassword = rSystemUser.AccountPassword;
                            //取得公司資訊
                            var oShareCompany = new ShareCompanyDao();
                            var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);

                            //向api取得驗証
                            var oSignin = new SigninDao();
                            var SigninCond = new SigninConditions();
                            SigninCond.UserId = UserId;
                            SigninCond.Password = AccountPassword;
                            SigninCond.CompanySetting = CompanySetting;
                            var Result = oSignin.GetData(SigninCond);

                            var AccessToken = "";
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

                            if (PassApi)
                            {
                                //超過效期
                                var DateA = rSystemUser.DateA.Date;
                                var DateD = rSystemUser.DateD.Date;
                                var NowDate = oMainDao._NowDate.Date;

                                if (!PassApi)
                                    if (DateA > NowDate || DateD < NowDate)
                                    {
                                        var oMessageShow = oMainDao.MessageShow("0903000002");
                                    }

                                UserCodeOld = _User.UserCode;
                                var UserCodeNew = AccountCode;

                                //暫時換人
                                //AccountCode = "000008";

                                var oUser = new User();
                                oUser.EmpId = AccountCode;
                                oUser.CompanyId = CompanyId;
                                oUser.EmpName = "";
                                oUser.RoleKey = RoleKey;
                                oUser.UserCode = AccountCode;
                                oUser.UserPassword = AccountPassword;
                                oUser.UserCodeOriginal = AccountCode;
                                oUser.LoginStatus = "1";

                                oUser.AccessToken = AccessToken;
                                oUser.RefreshToken = RefreshToken;

                                _AuthManager.SignIn(oUser, UserCodeOld, CompanySetting);

                                //撰寫歡迎訊息
                                {
                                    var oMainDao = new MainDao();
                                    var oMessageShow = oMainDao.MessageShow("0803000002");
                                    var oSystemUserNotify = new SystemUserNotifyDao();
                                    var oSystemUserNotifyInsert = new SystemUserNotifyInsertRow();
                                    oSystemUserNotifyInsert.IpAddress = WebPage.GetClientIP(Context);
                                    oSystemUserNotifyInsert.AppName = Request.Url.ToString();
                                    oSystemUserNotifyInsert.InsertMan = UserCode;
                                    oSystemUserNotifyInsert.ListSystemUserNotify = new List<SystemUserNotifyRow>();
                                    var rSystemUserNotify = new SystemUserNotifyRow();
                                    rSystemUserNotify.Code = Guid.NewGuid().ToString();
                                    rSystemUserNotify.UserCode = UserCode;
                                    rSystemUserNotify.UserCodeSend = "01";
                                    rSystemUserNotify.UserName = "系統管理者";
                                    rSystemUserNotify.NotifyTypeCode = "01";
                                    rSystemUserNotify.AppName = "Login";
                                    rSystemUserNotify.AppCode = UserCode;
                                    rSystemUserNotify.TitleContents = oMessageShow?.TitleContents ?? "歡迎回來";
                                    rSystemUserNotify.Contents = oMessageShow?.Contents ?? "今天簽到了嗎？";
                                    rSystemUserNotify.IsRead = false;
                                    rSystemUserNotify.DateA = DateTime.Now.Date;
                                    rSystemUserNotify.DateD = DateTime.Now.Date;
                                    oSystemUserNotifyInsert.ListSystemUserNotify.Add(rSystemUserNotify);
                                    oSystemUserNotify.SystemUserNotifyInsert(oSystemUserNotifyInsert);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //catching the exception
                oMainDao.MessageLog("3", "系統錯誤", ex.ToString(), Request.Url.ToString(), WebPage.GetClientIP(Context), _User.UserCode);
                ReturnUrl = "LoginBind.aspx";
            }
        }

        public class UserOutputData
        {
            public string id { get; set; }
            public string name { get; set; }
            public string given_name { get; set; }
            public string email { get; set; }
            public string picture { get; set; }
            public UserOutputData()
            {
                id = "";
                name = "";
                given_name = "";
                email = "";
                picture = "";
            }
        }

        public class AccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string id_token { get; set; }
            public string refresh_token { get; set; }
        }
    }
}