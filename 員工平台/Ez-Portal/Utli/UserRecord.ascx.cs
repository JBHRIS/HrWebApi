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

public partial class Utli_UserRecord : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetData();            
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }

    void GetData()
    {
        HRDs.sysLoginTimeDataTable rq_login = new HRDsTableAdapters.sysLoginTimeTableAdapter().GetDataBy_Date();
        GridView1.DataSource = rq_login;
        GridView1.DataBind();
    }
}
