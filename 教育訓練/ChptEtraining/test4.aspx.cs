using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
using Telerik.Web.UI;public partial class test4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //RadWindowManager1.RadAlert("test", 800, 600, "testTitle", "");
        
        //RadScriptManager.RegisterStartupScript(this, this.GetType(), "SWFScript", sSWF, false);
        //RadScriptManager.RegisterStartupScript(this, this.GetType(), "StopAllMedia", "", false);
        RadScriptManager.RegisterStartupScript(this, this.GetType(), "Test", "StopAllMedia()", false);
        
        
            //RegisterStartupScript
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        sysRole_Repo roleRepo = new sysRole_Repo();
        RadGrid1.DataSource = roleRepo.GetAll();
    }
}