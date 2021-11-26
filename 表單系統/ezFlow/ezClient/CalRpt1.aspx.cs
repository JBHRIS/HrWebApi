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

public partial class CalRpt1 : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		DateTime DateB = Convert.ToDateTime(Session["ReportYear"].ToString() + "/" + Session["ReportMonth"].ToString() + "/1 00:00:00");
		DateTime DateE = Convert.ToDateTime(Session["ReportYear"].ToString() + "/" + Session["ReportMonth"].ToString() + "/" +
			DateTime.DaysInMonth(Convert.ToInt32(Session["ReportYear"]),Convert.ToInt32(Session["ReportMonth"])).ToString() + " 23:59:59");
		ezClientDS dsCalRpt = new ezClientDS();
		Module.adCalendar.FillByDate(dsCalRpt.Calendar, DateB, DateE);
		foreach(ezClientDS.CalendarRow rowCalendar in dsCalRpt.Calendar.Rows) {
			if(rowCalendar.calType == "1") {
				rowCalendar.content = "私人行程，內容不公開。";
			}
		}
		dsCalRpt.Calendar.AcceptChanges();
		Module.adRole.Fill(dsCalRpt.Role);
		Module.adDept.Fill(dsCalRpt.Dept);
		Module.adEmp.Fill(dsCalRpt.Emp);

		CrystalReportSource1.ReportDocument.SetDataSource(dsCalRpt);
    }
}
