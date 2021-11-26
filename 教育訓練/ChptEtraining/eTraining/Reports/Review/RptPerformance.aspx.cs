using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Repo;
public partial class eTraining_Reports_Review_RptPerformance : JBWebPage
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
        try
        {
            //select m.dDateTimeA 上課日期時間,ca.sName 階層,co.sName 課程名稱,tea.sName 講師,m.iStudentNum 應到人數,COUNT(bPresence) 實到人數
            //from trTrainingDetailM m
            //join trCategory ca on m.sKey=ca.sCode
            //join trCourse co on m.trCourse_sCode=co.sCode
            //join trAttendClassTeacher t on m.iAutoKey=t.iClassAutoKey
            //join trTeacher tea on t.sTeacherCode=tea.sCode
            //join trTrainingStudentM s on m.iAutoKey=s.iClassAutoKey
            //where m.dDateA between '2011-09-01' and '2011-09-30' and s.bPresence=0
            //group by m.dDateTimeA,ca.sName,co.sName,tea.sName,m.iStudentNum

            //var performance = from m in dcTrain.trTrainingDetailM
            //                  join ca in dcTrain.trCategory on m.sKey equals ca.sCode
            //                  join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
            //                  join t in dcTrain.trAttendClassTeacher on m.iAutoKey equals t.iClassAutoKey
            //                  join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode
            //                  join s in dcTrain.trTrainingStudentM on m.iAutoKey equals s.iClassAutoKey
            //                  where m.iYear == Convert.ToInt32(cbxYear.SelectedValue) //&& s.bPresence == true
            //                      // && m.dDateA.Value.Month == Convert.ToInt32(cbxMonth.SelectedValue) //月份篩選
            //                  && m.dDateA >= dpA.SelectedDate && m.dDateA <= dpD.SelectedDate //日期區間
            //                  && m.bIsPublished == true
            //                  //&& m.dDateA >= "" && m.dDateA <="" //月份篩選
            //                  //                          group new { a, c } by new { b.sName, a.sCode, sName1 = a.sName } into gp
            //                  //                          let sum1 = gp.Sum(p => p.c.iDemandIntensityM)
            //                  group new { m, ca, co, tea, s } by new { m.dDateTimeA, Cate = ca.sName, Course = co.sName, Teacher = tea.sName, m.iStudentNum } into gp
            //                  let Presence = gp.Count(p => p.s.bPresence == true)
            //                  select new
            //                  {
            //                      Date = gp.Key.dDateTimeA,
            //                      Cate = gp.Key.Cate,
            //                      Course = gp.Key.Course,
            //                      Teacher = gp.Key.Teacher,
            //                      eStudentNum = gp.Key.iStudentNum,
            //                      aStudentNum = Presence
            //                  };

            trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
            List<trTrainingDetailM> list = tdmRepo.GetByDateRangePublished_DLO(dpA.SelectedDate.Value, dpD.SelectedDate.Value);

            Reports.PerformanceDataTable perform = new Reports.PerformanceDataTable();

            Course course = new Course();

            foreach (var itm in list)
            {
                Reports.PerformanceRow row = perform.NewPerformanceRow();

                row.Date = itm.dDateTimeA.Value;
                row.Time = itm.dDateTimeA.Value;
                //row.Cate = itm.trCategory.sName;
                row.Cate = itm.trCourse.trCategoryCourse[0].trCategory.sName;
                row.Course = itm.trCourse.sName;
                row.Teacher = course.GetTeacherNameByClassID(itm.iAutoKey);
                row.PeopleE = Convert.ToInt32(itm.iStudentNum);
                row.PeopleA = itm.trTrainingStudentM.Where(p => p.bPresence == true).Count();

                perform.AddPerformanceRow(row);
            }

            //foreach (var itm in performance)
            //{
            //    Reports.PerformanceRow row = perform.NewPerformanceRow();

            //    row.Date = Convert.ToDateTime(itm.Date);
            //    row.Time = Convert.ToDateTime(itm.Date);
            //    row.Cate = itm.Cate;
            //    row.Course = itm.Course;
            //    row.Teacher = itm.Teacher;
            //    row.PeopleE = itm.eStudentNum.ToString();
            //    row.PeopleA = itm.aStudentNum.ToString();

            //    perform.AddPerformanceRow(row);
            //}

            if (perform.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("performance", perform.CopyToDataTable()));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (Convert.ToInt32(cbxYear.SelectedValue) - 1911).ToString()));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("Month", cbxMonth.SelectedValue));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                throw new Exception("無資料");

            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}