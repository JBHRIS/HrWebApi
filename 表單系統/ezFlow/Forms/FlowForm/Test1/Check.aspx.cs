using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test1_Check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        localhost.Service oSer = new localhost.Service();

        int id = oSer.GetApParm(Convert.ToInt32(Request["ApParm"])).ProcessFlow_id;

        if (oSer.WorkFinish(Convert.ToInt32(Request["ApParm"])))
            Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", "alert('您的申請單已成功送出了');self.location = '../../FlowImage/Output.aspx?idProcess=" + id.ToString() + "';", true);
    }
}
