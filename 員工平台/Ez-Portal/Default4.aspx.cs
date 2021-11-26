using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JB.WebModules;
using JB.WebModules.Authentication;


public partial class _Default4 : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                //if ((Context.User is JBPrincipal))
                //{
                    // ASP.NET's regular forms authentication picked up our cookie, but we
                    // haven't replaced the default context user with our own. Let's do that
                    // now. We know that the previous context.user.identity.name is the e-mail
                    // address (because we forced it to be as such in the login.aspx page)	

                    JBPrincipal newUser = new JBPrincipal(Context.User.Identity.Name);

                    AbsList1.SetValue(JbUser.NOBR);
                    AbsList1.BindData();

                    if (newUser.Roles.Contains("HR"))
                    {
                        //RoteChgViewControl1.Visible = true;
                        //RotationWithNoAttendControl1.Visible = true;
                    }
                    else
                    {
                        //RoteChgViewControl1.Visible = false;
                        //RotationWithNoAttendControl1.Visible = false;
                    }                   
                //}
            }
            else
            {
                Response.Redirect(BaseUrl + "login.aspx", true);
            }
            
        }
    }
}
