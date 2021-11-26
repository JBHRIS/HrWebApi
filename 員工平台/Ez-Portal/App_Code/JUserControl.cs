using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using JB.WebModules.Authentication;

/// <summary>
/// JMasterPage 的摘要描述
/// </summary>
public class JUserControl : System.Web.UI.UserControl
{
    public string SessionName { get; set; }
    public string SessionName2 { get; set; }
	public JUserControl()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    protected override void OnInit(EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
            HttpContext.Current.Response.End();
        }
        SessionName = Page.GetType().ToString() + this.GetType().ToString();
        SessionName2 = Page.GetType().ToString() + this.GetType().ToString()+"2";
        base.OnInit(e);
    }

    public JUser Juser
    {
        get
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                return JUser.GetCacheUser(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
                return null;
            }
        }
    }

    public JB.WebModules.Accounts.User JbUser
    {
        get
        {
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
            catch
            {
                Response.Redirect(BaseUrl + "login.aspx", true);
            }
            return null;
        }
    }

    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }
}