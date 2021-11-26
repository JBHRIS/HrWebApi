using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JB.WebModules.Authentication;

/// <summary>
/// JBUserControl 的摘要描述
/// </summary>
public class JBUserControl : System.Web.UI.UserControl {
    public JBUserControl() {
        //
        // TODO: 在此加入建構函式的程式碼
        //

    }

    public JUser Juser
    {
        get
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                return JUser.GetCacheUser(Context.User.Identity.Name);
            }
            else
            {
                Response.Redirect(BaseUrl + "login.aspx", true);
                //FormsAuthentication.RedirectToLoginPage();
                return null;
            }
        }
    }

    public JB.WebModules.Accounts.User JbUser {
        get {
            try
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                    Context.User = newUser;

                    return ((SiteIdentity)Context.User.Identity).JbUser;

                }
                else
                {
                    Response.Redirect(BaseUrl + "login.aspx", true);
                }
            }
            catch {
                Response.Redirect(BaseUrl + "login.aspx", true);
            }
            return null;
        }
    }
    public string BaseUrl {
        get {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }
}
