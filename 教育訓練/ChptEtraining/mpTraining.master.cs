using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Security.Principal;
using System.Web.Security;
using Repo;
public partial class mpTraining : JMasterPage
{    
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private SiteHelper siteHelper = new SiteHelper();
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Page.Header.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            lblNobr.Text = Juser.Nobr;
            lblName.Text = Juser.NameC;
            lblDept.Text = Juser.DeptName;

            siteHelper.SetMainTvRootValues("Root", menu, Juser);
        }
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~/login.aspx",true);
    }
    protected void lbtnLogout_Click1(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        JUser.ClearCacheUser(Juser.Nobr);

        string portalSite = System.Web.Configuration.WebConfigurationManager.AppSettings["PortalSite"];
        if (portalSite != null)
            Response.Redirect(portalSite, true);
        else
            Response.Redirect("~/Login.aspx", true); 
    }
}