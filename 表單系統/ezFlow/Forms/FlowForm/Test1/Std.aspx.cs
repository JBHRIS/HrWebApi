using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test1_Std : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        localhost.Service oService = new localhost.Service();

        int id = oService.GetProcessID();

        if (oService.FlowStart(id, Request["idFlowTree"], Request["idRole_Start"], Request["idEmp_Start"], Request["idRole_Start"], Request["idEmp_Start"]))
            Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + id.ToString() + "';", true);
    }
}