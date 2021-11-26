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
using System.Collections.Generic;
using System.Linq;

public partial class Attendance_Abs1Select : JBWebPage {
    private ABS1_REPO abs1Repo = new ABS1_REPO();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {

            lb_nobr.Text = JbUser.NOBR;
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;
            siteHelper.SetDateRangeForThisYear(out startDatetime , out endDatetime );
            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;

            bindGv();
        }
    }
    protected void Button1_Click(object sender, EventArgs e) {
        bindGv();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        var list =abs1Repo.GetByNobrDateRange_Dlo(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView1, list, "ABS1.xls");
        
    }


    private void bindGv()
    {
       GridView1.DataSource= abs1Repo.GetByNobrDateRange_Dlo(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value).OrderByDescending(p=>p.AbsDate).ToList();
       GridView1.DataBind();
    }
}
