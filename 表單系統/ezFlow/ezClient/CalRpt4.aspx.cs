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

public partial class CalRpt4 : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		DateTime DateB = Convert.ToDateTime(Session["ReportYear"].ToString() + "/" + Session["ReportMonth"].ToString() + "/1 00:00:00");
		DateTime DateE = Convert.ToDateTime(Session["ReportYear"].ToString() + "/" + Session["ReportMonth"].ToString() + "/" +
			DateTime.DaysInMonth(Convert.ToInt32(Session["ReportYear"]), Convert.ToInt32(Session["ReportMonth"])).ToString() + " 23:59:59");

		ezClientDS dsCalRpt = new ezClientDS();

		Module.adCalendarAll.FillByType1(dsCalRpt.CalendarAll, DateB, DateE);
		Module.adEmp.Fill(dsCalRpt.Emp);

		CrystalReportSource1.ReportDocument.SetDataSource(dsCalRpt);
    }
}
