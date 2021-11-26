using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using System.Text;
public partial class UC_UC_ClassCalendar : System.Web.UI.UserControl
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private List<trTrainingDetailM> classObjs = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            calClassObjs();
        }        
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        string excelFileName = "AttSum.xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        DateTime adate = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, 1);
        DateTime ddate = adate.AddMonths(1);
        calClassObjs();

        Calendar1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (classObjs == null)
        {
            calClassObjs();
        }

        var objs = (from c in classObjs
                    where c.dDateA.Value == e.Day.Date
                    select c).ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var obj in objs)
        {
            Label lbl = new Label();
            e.Cell.Controls.Add(lbl);
            sb.Clear();
            sb.Append(@"<div class='CalendarLeft'>");
            sb.Append(obj.dDateTimeA.Value.ToString("HH:mm"));
            sb.Append("-");
            sb.Append(obj.dDateTimeD.Value.ToString("HH:mm"));
            sb.Append(obj.trCourse.sName);
            sb.Append(@"</div>");
            lbl.Text = sb.ToString();
        }
    }
    protected void Calendar1_Load(object sender, EventArgs e)
    {
        
    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        lblDate.Text = new DateTime(e.NewDate.Year, e.NewDate.Month, 1).ToShortDateString();
        calClassObjs();
    }

    private void calClassObjs()
    {
        DateTime date ;
        if (!DateTime.TryParse(lblDate.Text, out date))
            date = DateTime.Now;

        DateTime adate = new DateTime(date.Year, date.Month, 1);
        DateTime ddate = adate.AddMonths(1);

        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        classObjs = tdmRepo.GetByDateRangePublished_DLO(adate , ddate);
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblDate.Text = Calendar1.SelectedDate.ToShortDateString();
        calClassObjs();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}