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

public partial class Output : System.Web.UI.Page
{
    public bool IsWap()
    {
        HttpBrowserCapabilities hbc = Request.Browser;
        string agent = (Request.UserAgent + "").ToLower().Trim();
        bool bWap = agent.IndexOf("phone") > 0; //如果是手機
        if (bWap) return true;
        if (agent.IndexOf("windows") > 0) return false; //如果是桌機
        bWap = bWap ? bWap : hbc.Browser == "AppleMAC-Safari";  //如果是手機
        return bWap;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsWap())
            Response.Redirect("http://" + Request.Url.Host + "/ezFlow/ezClient/HomeM.aspx");

		Session["idProcess"] = Convert.ToInt32(Request["idProcess"]);
		//Session["idProcess"] = 36;
    }
}
