using System;
using System.Linq;
using System.Web.UI.WebControls;
using BL;

public partial class Templet_NewsContral : JBUserControl
{
    private news_REPO nRepo = new news_REPO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = nRepo.GetByNobrDept(Juser.Nobr, Juser.Dept, DateTime.Now.Date.AddYears(-1), DateTime.Now.Date).Take(5);
            GridView1.DataBind();
        }
        //lb_adate.Text = DateTime.Now.AddMonths(-3).ToShortDateString();
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count == 0)
            this.Visible = false;
        else
            this.Visible = true;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = nRepo.GetByNobrDept(Juser.Nobr, Juser.Dept);
        GridView1.DataBind();
    }
}