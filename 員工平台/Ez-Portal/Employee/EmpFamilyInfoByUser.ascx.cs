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

public partial class Employee_EmpFamilyInfoByUser : JBUserControl, ICU
{

     
    public void bindGrid()
    {
        GridView2.DataBind();
        GridView1.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e) {
        //if (!IsPostBack)
        //    lb_nobr.Text = JbUser.NOBR;


      

      
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 5) + "xxxxx";
        }
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        if (lb_nobr.Text.Trim().Equals(JbUser.NOBR.Trim()))
        {
            GridView2.Visible = true;
            GridView1.Visible = false;

        }
        else
        {
            GridView1.Visible = true;
            GridView2.Visible = false;

        }
    }
}
