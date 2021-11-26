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
using JB.WebModules.Authentication;

public partial class Employee_EmpSchl : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            lb_nobr.Text = JbUser.NOBR;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (bool.Parse(e.Row.Cells[6].Text))
                e.Row.Cells[6].Text = "V";
            else
                e.Row.Cells[6].Text = "";
        }
         
    }
}
