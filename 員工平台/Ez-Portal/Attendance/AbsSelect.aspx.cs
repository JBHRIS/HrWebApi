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
using BL;

public partial class Attendance_AbsSelect : JBWebPage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            lb_nobr.Text = JbUser.NOBR;
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;
            siteHelper.SetDateRangeForThisYear(out startDatetime, out endDatetime);

            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;
        }
    }
    protected void Button1_Click(object sender, EventArgs e) {
        GridView1.DataBind();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        
         //   JB.WebModules.Data.Export.Excel.WebResponseExcel(
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[5].Text);
            e.Row.Cells[6].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[6].Text);
        }
    }
}
