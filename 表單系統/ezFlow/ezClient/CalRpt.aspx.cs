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

public partial class CalRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string DateB = Session["ReportYear"].ToString() + "/" + Session["ReportMonth"].ToString() + "/1 00:00:00";
		string DateE = Session["ReportYear"].ToString() + "/" + Session["ReportMonth"].ToString() + "/" +
			DateTime.DaysInMonth(Convert.ToInt32(Session["ReportYear"].ToString()), Convert.ToInt32(Session["ReportMonth"].ToString())).ToString() + " 23:59:59";

		ezClientDSTableAdapters.EmpTableAdapter adEmp = new ezClientDSTableAdapters.EmpTableAdapter();
		adEmp.ClearBeforeFill = false;
		ezClientDSTableAdapters.CalendarTableAdapter adCalendar = new ezClientDSTableAdapters.CalendarTableAdapter();
		adCalendar.ClearBeforeFill = false;
		
		ezClientDS dsClient = new ezClientDS();

		string strTmp = Session["ReportEmps"].ToString();
		if(strTmp.IndexOf(',') != -1) {
			string[] aryEmpID = strTmp.Split(new char[] { ',' });
			foreach(string EmpID in aryEmpID) {
				ezClientDS.EmpDataTable dtEmpTmp = adEmp.GetDataByLogin(EmpID);
				if(dtEmpTmp.Count > 0) {
					dsClient.Emp.ImportRow(dtEmpTmp[0]);
					adCalendar.FillByEmpCal(dsClient.Calendar, dtEmpTmp[0].id, Convert.ToDateTime(DateB), Convert.ToDateTime(DateE));
				}
			}
		}
		else {
			ezClientDS.EmpDataTable dtEmpTmp = adEmp.GetDataByLogin(strTmp);
			if(dtEmpTmp.Count > 0) {
				dsClient.Emp.ImportRow(dtEmpTmp[0]);
				adCalendar.FillByEmpCal(dsClient.Calendar, dtEmpTmp[0].id, Convert.ToDateTime(DateB), Convert.ToDateTime(DateE));
			}
		}

		if(dsClient.Calendar.Count > 0) {
			foreach(ezClientDS.CalendarRow rowCalendar in dsClient.Calendar.Rows) {
				if(rowCalendar.calType == "1") rowCalendar.content = "私人行程，內容不公開。";
				if(rowCalendar.msgType == "2") rowCalendar.Delete();
			}
		}
		dsClient.Calendar.AcceptChanges();

		CrystalReportSource1.ReportDocument.SetDataSource(dsClient);
    }
}
