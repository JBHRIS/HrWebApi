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

public partial class Utli_OnlineList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = "目前上線人數：" + AppUser.getUserList(this.Page).Rows.Count.ToString();
            DataTable rq_test = (DataTable)AppUser.getUserList(this.Page);            
            GridView1.DataSource = (DataTable)AppUser.getUserList(this.Page);
            GridView1.DataBind();
        }
    }
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
}
