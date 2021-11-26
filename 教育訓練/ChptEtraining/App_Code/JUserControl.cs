using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;

/// <summary>
/// JMasterPage 的摘要描述
/// </summary>
public class JUserControl : System.Web.UI.UserControl
{
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

        base.OnInit(e);
    }

    public JUser Juser
    {
        get
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);
                return JUser.GetCacheUser(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
                return null;
            }
        }
    }
}