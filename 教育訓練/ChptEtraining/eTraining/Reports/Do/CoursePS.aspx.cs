using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Do_CoursePS : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);
            //預設當月到當日日期區間
            dpStart.SelectedDate = DateTime.Now.Date.AddDays(-DateTime.Now.Day+1);
            dpEnd.SelectedDate = DateTime.Now;
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            //處理有實際開課的
            var courseM = (from m in dcTrain.trTrainingDetailM
                           join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                           join s in dcTrain.trTrainingStudentM on m.iAutoKey equals s.iClassAutoKey
                           where //m.dDateA.Value.Month == Convert.ToInt16(cbxMonth.SelectedValue)
                           m.dDateA >= dpStart.SelectedDate && m.dDateA <= dpEnd.SelectedDate
                           && m.iYear == Convert.ToInt32(cbxYear.SelectedValue) //&& s.bPresence == true
                           group new { m, ca, s } by new { ca.sName, m.iYearPlanAutoKey, m.iStudentNum, ca.sCode } into gp
                           let Presence = gp.Count(p => p.s.bPresence)
                           //orderby gp.Key.sName //排序
                           select new
                           {
                               Cate = gp.Key.sName,
                               CateCode = gp.Key.sCode,
                               IsPlan = gp.Key.iYearPlanAutoKey,
                               eStudentNum = gp.Key.iStudentNum,
                               aStudentNum = Presence
                           }).ToList();

            //courseM.OrderBy(c => c.CateCode);

            Reports.CoursePSDataTable coursePS = new Reports.CoursePSDataTable();

            foreach (var itm in courseM)
            {

                var rep = coursePS.FindByCate(itm.Cate);
                if (rep != null)
                {
                    //rep.CourseP += itm.eStudentNum;
                    //rep.CourseM += itm.aStudentNum;
                    rep.eStudentNum += (Double)itm.eStudentNum;
                    rep.aStudentNum += itm.aStudentNum;
                    //Show("有重複");
                }
                else
                {
                    Reports.CoursePSRow row = coursePS.NewCoursePSRow();

                    //抓取大類(課程別)
                    var Cate = (from ca1 in dcTrain.trCategory
                                join ca2 in dcTrain.trCategory on ca1.sCode equals ca2.sParentCode
                                where ca2.sName == itm.Cate
                                select ca1).FirstOrDefault();

                    row.CateB = Cate.sName;
                    row.Cate = itm.Cate;
                    row.CourseM = "○";
                    row.eStudentNum = Convert.ToInt32(itm.eStudentNum);
                    row.aStudentNum = itm.aStudentNum;

                    if (itm.eStudentNum != null)
                    {
                        row.CourseRate = ((Double)itm.aStudentNum / (Double)(itm.eStudentNum) * 100).ToString();
                    }
                    //若由年度計劃開課的課程
                    if (itm.IsPlan != null)
                    {
                        row.CourseP = "○";
                        row.CourseRate = "";
                    }
                    coursePS.AddCoursePSRow(row);
                }
            }

            //處理有年度計畫，卻沒開課的
            var courseP = (from p in dcTrain.trTrainingPlanDetail
                           join ca in dcTrain.trCategory on p.sKey equals ca.sCode
                           where p.iMonth == Convert.ToInt16(cbxMonth.SelectedValue) && p.iClassAutoKey == null
                           select new { Cate = ca.sName }).ToList();

            foreach (var p in courseP)
            {
                var rep = coursePS.FindByCate(p.Cate);
                if (rep != null)
                {
                    rep.CourseP = "○";
                }
                else
                {
                    Reports.CoursePSRow row = coursePS.NewCoursePSRow();

                    //抓取大類(課程別)
                    var Cate = (from ca1 in dcTrain.trCategory
                                join ca2 in dcTrain.trCategory on ca1.sCode equals ca2.sParentCode
                                where ca2.sName == p.Cate
                                select ca1).FirstOrDefault();

                    row.CateB = Cate.sName;
                    row.Cate = p.Cate;
                    row.CourseP = "○";
                    //row.CourseRate = "";

                    coursePS.AddCoursePSRow(row);
                }
            }



            if (coursePS.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("coursePS", coursePS.CopyToDataTable()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Month", cbxMonth.SelectedValue));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("DateA", dpStart.SelectedDate.ToString()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("DateB", dpEnd.SelectedDate.ToString()));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.ZoomMode = ZoomMode.Percent;
                ReportViewer1.ZoomPercent = 100;
                //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            }
            else
            {
                AlertMsg("無資料");
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }

    }
}