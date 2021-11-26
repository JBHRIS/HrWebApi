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

public partial class Employee_EmpFamilyInfo : JBUserControl, ICU
{
    public void bindGrid()
    {
        GridView2.DataBind();
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e) {
        if ( !IsPostBack )
        {
            lb_nobr.Text = JbUser.NOBR;
            GridView2.Visible = false;
            GridView1.Visible = true;

            //if ( lb_nobr.Text.Trim().Equals(JbUser.NOBR.Trim()) )
            //{
            //    GridView2.Visible = true;
            //    GridView1.Visible = false;
            //}
            //else
            //{
            //    GridView1.Visible = true;
            //    GridView2.Visible = false;
            //}
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text.Length>5)
                e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 5) + "xxxxx";
        }
    }
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cb1 =e.Row.Cells[5].Controls[0] as CheckBox;
            if ( cb1 != null )
            {
                //cb1.Attributes.Add("style", "color: red;background-color: aqua"); 
                  cb1.Enabled =true;
                   cb1.Attributes.Add("onclick", "return false");
            }
            CheckBox cb2 = e.Row.Cells[6].Controls[0] as CheckBox;
                  if ( cb2 != null )
                  {
                      cb2.Enabled = true;
                      cb2.Attributes.Add("onclick" , "return false");
                  }               
                
            //cb2.Attributes.Add("style" , "color: red;background-color: aqua"); 
        }
    }
}
