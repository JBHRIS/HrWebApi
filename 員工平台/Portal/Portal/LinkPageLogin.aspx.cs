using Bll.Token.Vdb;
using Dal.Dao.Share;
using Dal.Dao.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;

namespace Portal
{
    public partial class LinkPageLogin : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _AuthManager.SignOut();
            if (_User != null)
            {
                _AuthManager.ClearCacheUser(_User.Connection + _User.EmpId);
            }
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
            var AccessToken = Request.QueryString["AccessToken"];
            var RefreshToken = Request.QueryString["RefreshToken"];
            var Company = Request.QueryString["Company"];
            if (AccessToken != null && AccessToken != "" && RefreshToken != null && RefreshToken != "" && Company != null && Company != "")
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", Company));

                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(Company);
                UnobtrusiveSession.Session["CompanySetting"] = CompanySetting;
                var oUser = new User();
                oUser.UserCode = "";
                oUser.UserCodeOriginal = "";
                oUser.AccessToken = AccessToken;
                oUser.RefreshToken = RefreshToken;
                oUser.LoginStatus = "1";
                _AuthManager.SignIn(oUser, "", CompanySetting);

                //手機版本沒有登出按鈕
                UnobtrusiveSession.Session["App"] = true;
                Response.Redirect("Index.aspx");
               
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        
    }
}