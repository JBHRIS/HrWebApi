using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_Attendance : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);

            dpA.SelectedDate = DateTime.Today.AddDays(-DateTime.Today.Day + 1); //當月月初
            dpD.SelectedDate = DateTime.Today;
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        dcTrain.Log = new DebuggerWriter();

        try
        {
            var Attendance = (from m in dcTrain.trTrainingDetailM
                              join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                              join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
                              //join t in dcTrain.trAttendClassTeacher on m.iAutoKey equals t.iClassAutoKey //2013-04-09註解，因上課講師有多個，抓取講師資料課程會變成多筆(忘記當初為什麼要抓講師資料了)
                              //join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode //2013-04-09註解
                              join s in dcTrain.trTrainingStudentM on m.iAutoKey equals s.iClassAutoKey
                              where m.bIsPublished == true
                              //&& ca.sCode == cbxCate.SelectedValue //階層
                              && m.dDateA >= dpA.SelectedDate && m.dDateA <= dpD.SelectedDate //日期區間
                              //&& m.iYear == Convert.ToInt32(cbxYear.SelectedValue) //&& s.bPresence == true
                              && m.bIsPublished == true
                              //group new { m, ca, co, tea, s } by new { m.iYear, m.iSession, m.dDateTimeA, Cate = ca.sName, Course = co.sName, Teacher = tea.sName, m.iStudentNum } into gp //2013-04-09註解
                              group new { m, ca, co, s } by new { m.iYear, m.iSession, m.dDateTimeA, Cate = ca.sName, Course = co.sName, m.iStudentNum } into gp
                              let Presence = gp.Count(p => p.s.bPresence)
                              select new
                              {
                                  Date = gp.Key.dDateTimeA,
                                  Cate = gp.Key.Cate,
                                  Course = gp.Key.Course,
                                  //Teacher = gp.Key.Teacher, //2013-04-09註解
                                  eStudentNum = gp.Key.iStudentNum,
                                  aStudentNum = Presence,
                                  Year = gp.Key.iYear,
                                  Session = gp.Key.iSession
                              }).ToList();

            //Reports.PerformanceDataTable att = new Reports.PerformanceDataTable();
            Reports.attDataTable att = new Reports.attDataTable();

            foreach (var itm in Attendance)
            {
                //Reports.PerformanceRow row = att.NewPerformanceRow();
                Reports.attRow row = att.NewattRow();

                row.Year = itm.Year.ToString();
                row.Session = itm.Session.ToString();
                row.Cate = itm.Cate;
                row.Course = itm.Course;
                row.eStuNum = Convert.ToInt32(itm.eStudentNum);
                row.aStuNum = Convert.ToInt32(itm.aStudentNum);
                row.Date = Convert.ToDateTime(itm.Date);

                //att.AddPerformanceRow(row);
                att.AddattRow(row);
            }

            if (att.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("att", att.CopyToDataTable()));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.ZoomMode = ZoomMode.Percent;
                ReportViewer1.ZoomPercent = 100;
                //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            }
            else
            {
                AlertMsg("無資料");
                //Label1.Text = "無資料";
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}