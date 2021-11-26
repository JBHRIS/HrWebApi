using Bll.Role.Vdb;
using Bll.System.Vdb;
using Dal.Dao.Role;
using Bll.Tools;
using Dal.Dao.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design;
using Telerik.Web.UI;
using System.Text;

namespace Portal
{
    public partial class AuthAccountBind : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData();
            }
        }
        public void LoadData(string Key = "")
        {
            var rUser = (from c in dcShare.SystemUser
                         where c.AccountCode == _User.EmpId
                         select c).FirstOrDefault();

            if (rUser != null)
            {
                var DateNow = DateTime.Now;
                var UserCode = rUser.Code;

                var rsUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                         where c.UserCode == UserCode
                                         && c.Status == "1"
                                         && c.DateA <= DateNow && DateNow <= c.DateD
                                         select c).ToList();

                foreach (var rUserAccountBind in rsUserAccountBind)
                {
                    var ThirdPartyTypeCode = rUserAccountBind.ThirdPartyTypeCode;

                    switch (ThirdPartyTypeCode)
                    {
                        case "Facebook":
                            lblBindFacebook.Text = "已綁定";
                            break;
                        case "Google":
                            lblBindGoogle.Text = "已綁定";
                            break;
                        case "Line":
                            lblBindLine.Text = "已綁定";
                            break;
                    }
                }
            }
        }

        protected void btnBind_Click(object sender, EventArgs e)
        {
            var CommandName = ((RadButton)sender).CommandName;

            //已經登入的狀態 就不允許登入
            if (_User.LoginStatus == "1")
            {
                _AuthManager.SignOut();
                //var oMessageShow = oMainDao.MessageShow("0903000009");
                //lblMsg.Text = oMessageShow?.Contents ?? "目前是登入狀態，請先登出，如果您要綁定，請到個人帳號進行綁定";
                //return;
            }

            var loginWith = CommandName;
            var scope = "";
            var state = Guid.NewGuid().ToString();
            var redirect_uri = "";
            var clientId = "";
            var AuthUrl = "";

            UnobtrusiveSession.Session["User"] = _User;

            switch (CommandName)
            {
                case "Google":
                    {
                        UnobtrusiveSession.Session["DefaultOAuth2Google"] = null;
                        var DefaultOAuth2 = AccessData.DefaultOAuth2Google;

                        scope = DefaultOAuth2.Scope;
                        state = Guid.NewGuid().ToString();
                        redirect_uri = HttpUtility.UrlEncode(DefaultOAuth2.BindUrl);
                        clientId = DefaultOAuth2.ClientId;
                        AuthUrl = DefaultOAuth2.AuthUrl;
                    }
                    break;
                case "Facebook":
                    {
                        UnobtrusiveSession.Session["DefaultOAuth2Facebook"] = null;
                        var DefaultOAuth2 = AccessData.DefaultOAuth2Facebook;

                        scope = DefaultOAuth2.Scope;
                        state = Guid.NewGuid().ToString();
                        redirect_uri = HttpUtility.UrlEncode(DefaultOAuth2.BindUrl);
                        clientId = DefaultOAuth2.ClientId;
                        AuthUrl = DefaultOAuth2.AuthUrl;
                    }
                    break;
                case "Line":
                    {
                        UnobtrusiveSession.Session["DefaultOAuth2Line"] = null;
                        var DefaultOAuth2 = AccessData.DefaultOAuth2Line;

                        scope = DefaultOAuth2.Scope;
                        state = Guid.NewGuid().ToString();
                        redirect_uri = HttpUtility.UrlEncode(DefaultOAuth2.BindUrl);
                        clientId = DefaultOAuth2.ClientId;
                        AuthUrl = DefaultOAuth2.AuthUrl;
                    }
                    break;
            }

            var Url = $"{AuthUrl}?scope={scope}&state={state}&redirect_uri={redirect_uri}&response_type=code&client_id={clientId}&approval_prompt=force";

            UnobtrusiveSession.Session["state"] = state;
            UnobtrusiveSession.Session["loginWith"] = loginWith;
            Response.Redirect(Url);
        }
    }
}