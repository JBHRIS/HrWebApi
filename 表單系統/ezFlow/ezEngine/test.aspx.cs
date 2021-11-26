using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CMan c = COrg.GetManager(64, "AGD0E00A7101");

        //Service oService = new Service();
        //oService.WorkFinish(90);
        Service oService = new Service();

        oService.FlowStart(oService.GetProcessID(), "15", "ABABCA0C3100", "10100082", "ABABCA0C3100", "10100082");

    }
}
