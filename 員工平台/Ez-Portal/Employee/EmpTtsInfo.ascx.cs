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

public partial class Employee_EmpTtsInfo : JBUserControl {
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack)
            lb_nobr.Text = JbUser.NOBR;
        
    }
    protected void DetailsView1_DataBinding(object sender, EventArgs e) {

    }
    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        if (DetailsView1.Rows.Count > 6)
        {
            DetailsView1.Rows[6].Visible = JbUser.IsMang;

            if (JbUser.NOBR.Trim().Equals(lb_nobr.Text.Trim()))
            {

                DetailsView1.Rows[6].Visible = false;
            }
        }
    }
}
