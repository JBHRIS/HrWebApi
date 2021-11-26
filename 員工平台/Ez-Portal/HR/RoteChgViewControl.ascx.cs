using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class HR_RoteChgViewControl : System.Web.UI.UserControl
{
    private HIDsTableAdapters.RoteChgViewTableAdapter roteChgViewAdap = new HIDsTableAdapters.RoteChgViewTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            radAdate.SelectedDate = DateTime.Parse(DateTime.Now.AddMonths(-1).Year.ToString() + "/" + DateTime.Now.AddMonths(-1).Month + "/1");
            radDdate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());

            HIDs.RoteChgViewDataTable dt = roteChgViewAdap.GetDataByBTWDate(radAdate.SelectedDate.Value, radDdate.SelectedDate.Value);
            Session["RoteChgView"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


    }

    protected void btn_exportExcel_Click(object sender, EventArgs e)
    {                
        HIDs.RoteChgViewDataTable dt = roteChgViewAdap.GetDataByBTWDate(radAdate.SelectedDate.Value, radDdate.SelectedDate.Value);

        if (dt != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this.Page, GridView1, (HIDs.RoteChgViewDataTable)dt, "AttendError");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        HIDs.RoteChgViewDataTable dt = roteChgViewAdap.GetDataByBTWDate(radAdate.SelectedDate.Value, radDdate.SelectedDate.Value);
        GridView1.DataSource = dt;
        GridView1.DataBind();

        Session["RoteChgView"] = dt;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["sortDirection"] == null)
        {
            ViewState["sortDirection"] = "Asc";
        }

        if (ViewState["sortKey"] == null)
            ViewState["sortKey"] = "NOBR";

        if (Session["RoteChgView"] != null)
        {
            GridView1.PageIndex = e.NewPageIndex;

            DataView dataview = new DataView((HIDs.RoteChgViewDataTable)Session["RoteChgView"]);
            dataview.Sort = ViewState["sortKey"].ToString() + " " + ViewState["sortDirection"].ToString();
            
            GridView1.DataSource = dataview;
            GridView1.DataBind();
            
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        
        if (ViewState["sortDirection"] == null)
        {
            ViewState["sortDirection"] = "Asc";
        }

        if (ViewState["sortKey"] != null)
        {
            if (ViewState["sortKey"].ToString().Equals(e.SortExpression.ToString()))
            {
                if (ViewState["sortDirection"].ToString().Equals("Asc") )
                    ViewState["sortDirection"] = "Desc";
            }
            else
            {
                ViewState["sortDirection"] = "Asc";
            }

            ViewState["sortKey"] = e.SortExpression;
        }
        else
        {
            ViewState["sortKey"] = e.SortExpression;
        }

        if (Session["RoteChgView"] != null)
        {
            DataView dataview = new DataView((HIDs.RoteChgViewDataTable)Session["RoteChgView"]);
            dataview.Sort = e.SortExpression + " " + ViewState["sortDirection"].ToString();
            GridView1.DataSource = dataview;
            GridView1.DataBind();

        }                
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
}
