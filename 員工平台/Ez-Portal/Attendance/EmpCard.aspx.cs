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
 
using System.Collections.Generic;

public partial class Attendance_EmpCard : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lb_nobr.Text = JbUser.NOBR;
            Session["rv_card"] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session["rv_card"] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (HRDs.rv_cardDataTable)Session["rv_card"], "EmpCard");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        HRDsTableAdapters.rv_cardTableAdapter rv_card = new HRDsTableAdapters.rv_cardTableAdapter();
        HRDs.rv_cardDataTable rv_cardDs = new HRDs.rv_cardDataTable();
        rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));
        Session["rv_card"] = rv_cardDs;
        GridView2.DataSource = rv_cardDs;
        GridView2.DataBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["rv_card"] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (HRDs.rv_cardDataTable)Session["rv_card"];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
}
