using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.System;
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
    public partial class HandlerAuthBindFacebook : WebPageBase
    {
        protected string ThirdPartyTypeCode = "Facebook";

        protected string client_id = "";    // Replace this with your Client ID
        protected string client_secret = "";// Replace this with your Client Secret
        protected string redirect_url = ""; // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        protected string Parameters;

        public string ReturnUrl = "AuthAccountBind.aspx";

        DefaultOAuth2FacebookRow DefaultOAuth2 = AccessData.DefaultOAuth2Facebook;

        protected async void Page_Load(object sender, EventArgs e)
        {
            client_id = DefaultOAuth2.ClientId;
            client_secret = DefaultOAuth2.ClientSecret;
            redirect_url = HttpUtility.UrlEncode(DefaultOAuth2.BindUrl);
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

                                        _User = (User)UnobtrusiveSession.Session["User"];
                                        // This is where you want to add the code if login is successful.
                                        await getuserdataSer(accessToken, _User);

                                        ReturnUrl = "AuthAccountBind.aspx";
                                    }
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                    oMainDao.MessageLog("3", "系統錯誤", ex.ToString(), Request.Url.ToString(), WebPage.GetClientIP(Context), _User.UserCode);
                    ReturnUrl = "AuthAccountBind.aspx";
                }
            }

            Response.Redirect(ReturnUrl);
            if (!Response.IsRequestBeingRedirected)
                Response.Redirect(ReturnUrl);
        }

        private async Task getuserdataSer(string access_token, User oUser)
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
                        //var AccountCode = ThirdPartyTypeCode + "-" + ThirdPartyAccountId;
                        var PictureUrl = serStatus.picture; //縮圖

                        //一律重新綁定

                        var CompanyId = oUser.CompanyId;
                        var AccountCode = oUser.UserCode;
                        var AccountPassword = oUser.UserPassword;

                        //SystemUser如果沒有資料 就產生
                        var rSystemUser = (from c in dcShare.SystemUser
                                           where c.CompnayId == CompanyId
                                           && c.AccountCode == AccountCode
                                           select c).FirstOrDefault();

                        if (rSystemUser == null)
                        {
                            rSystemUser = new SystemUser();
                            rSystemUser.Code = Guid.NewGuid().ToString();
                            dcShare.SystemUser.InsertOnSubmit(rSystemUser);
                        }

                        rSystemUser.CompnayId = CompanyId;
                        rSystemUser.AccountCode = AccountCode;
                        rSystemUser.AccountPassword = AccountPassword;
                        rSystemUser.MoneyPassword = "";
                        rSystemUser.RoleKey = 64;
                        rSystemUser.DateA = DateTime.Now.Date;
                        rSystemUser.DateD = rSystemUser.DateA.AddYears(1);
                        rSystemUser.IsRegistered = true;
                        rSystemUser.Note = "";
                        rSystemUser.Status = "1";
                        rSystemUser.InsertMan = AccountCode;
                        rSystemUser.InsertDate = DateTime.Now;
                        rSystemUser.UpdateMan = AccountCode;
                        rSystemUser.UpdateDate = DateTime.Now;

                        var UserCode = rSystemUser.Code;

                        //SystemUserInfo如果沒有就產生
                        var rSystemUserInfo = (from c in dcShare.SystemUserInfo
                                               where c.UserCode == UserCode
                                               select c).FirstOrDefault();

                        if (rSystemUserInfo == null)
                        {
                            rSystemUserInfo = new SystemUserInfo();
                            rSystemUserInfo.Code = Guid.NewGuid().ToString();
                            dcShare.SystemUserInfo.InsertOnSubmit(rSystemUserInfo);
                        }

                        rSystemUserInfo.UserCode = UserCode;
                        rSystemUserInfo.UserName = UserName;
                        rSystemUserInfo.AnonymousName = AnonymousName;
                        rSystemUserInfo.Birthday = new DateTime(1900, 1, 1).Date;
                        rSystemUserInfo.CardId = "";
                        rSystemUserInfo.Address = "";
                        rSystemUserInfo.Tel = "";
                        rSystemUserInfo.TelA = new DateTime(1900, 1, 1).Date;
                        rSystemUserInfo.TelD = new DateTime(1900, 1, 1).Date;
                        rSystemUserInfo.Email = Email;
                        rSystemUserInfo.EmailA = new DateTime(1900, 1, 1).Date;
                        rSystemUserInfo.EmailD = new DateTime(1900, 1, 1).Date;
                        rSystemUserInfo.Sex = "";
                        rSystemUserInfo.Note = "";
                        rSystemUserInfo.Status = "1";
                        rSystemUserInfo.InsertMan = AccountCode;
                        rSystemUserInfo.InsertDate = DateTime.Now;
                        rSystemUserInfo.UpdateMan = AccountCode;
                        rSystemUserInfo.UpdateDate = DateTime.Now;

                        //SystemUserAccountBind如果沒有資料 就產生
                        var rSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                                      where c.ThirdPartyAccountId == ThirdPartyAccountId
                                                      && c.ThirdPartyTypeCode == ThirdPartyTypeCode
                                                      select c).FirstOrDefault();

                        if (rSystemUserAccountBind == null)
                        {
                            rSystemUserAccountBind = new SystemUserAccountBind();
                            rSystemUserAccountBind.Code = Guid.NewGuid().ToString();
                            dcShare.SystemUserAccountBind.InsertOnSubmit(rSystemUserAccountBind);
                        }

                        rSystemUserAccountBind.UserCode = UserCode;
                        rSystemUserAccountBind.ThirdPartyAccountId = ThirdPartyAccountId;
                        rSystemUserAccountBind.ThirdPartyTypeCode = ThirdPartyTypeCode;
                        rSystemUserAccountBind.DateA = DateTime.Now.Date;
                        rSystemUserAccountBind.DateD = rSystemUser.DateA.AddYears(1);
                        rSystemUserAccountBind.Note = "";
                        rSystemUserAccountBind.Status = "1";
                        rSystemUserAccountBind.InsertMan = AccountCode;
                        rSystemUserAccountBind.InsertDate = DateTime.Now;
                        rSystemUserAccountBind.UpdateMan = AccountCode;
                        rSystemUserAccountBind.UpdateDate = DateTime.Now;

                        //儲存縮圖
                        if (PictureUrl.Length > 0)
                        {
                            var oImageAccess = new ImageAccess();
                            var img = oImageAccess.GetThumbPic(PictureUrl, 50);
                            var Blob = ImageAccess.ImageToBytes(img, ImageFormat.Jpeg);

                            var Size = Blob.Length;
                            var Type = "image/jpeg";// img.RawFormat.ToString();
                            var ObjectName = "UserInfoPicture.jpg";
                            var Code = Guid.NewGuid().ToString();

                            var rShareUpload = (from c in dcShare.ShareUpload
                                                where c.Key1 == UserCode
                                                select c).FirstOrDefault();

                            if (rShareUpload == null)
                            {
                                rShareUpload = new ShareUpload();
                                rShareUpload.Code = Code;
                                dcShare.ShareUpload.InsertOnSubmit(rShareUpload);
                            }

                            rShareUpload.Code = Code;
                            rShareUpload.Key1 = UserCode;
                            rShareUpload.Key2 = "UserInfo";
                            rShareUpload.Key3 = "Picture";
                            rShareUpload.UploadName = ObjectName;
                            rShareUpload.ServerName = Code;
                            rShareUpload.Blob = Blob;
                            rShareUpload.Type = Type;
                            rShareUpload.Size = Size;
                            rShareUpload.Sort = 1;
                            rShareUpload.SystemUse = false;
                            rShareUpload.Note = "";
                            rShareUpload.Status = "1";
                            rShareUpload.InsertMan = AccountCode;
                            rShareUpload.InsertDate = DateTime.Now;
                            rShareUpload.UpdateMan = AccountCode;
                            rShareUpload.UpdateDate = DateTime.Now;
                        }

                        dcShare.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                //catching the exception
                oMainDao.MessageLog("3", "系統錯誤", ex.ToString(), Request.Url.ToString(), WebPage.GetClientIP(Context), _User.UserCode);
                ReturnUrl = "AuthAccountBind.aspx";
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