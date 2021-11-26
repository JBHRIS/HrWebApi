using System;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Collections.Generic;
using Repo;

public partial class eTraining_Reports_Review_RptTeacherCost : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);

            dpA.SelectedDate = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.Day)) + 1);
            dpD.SelectedDate = DateTime.Now;
        }

        List<string> test = new List<string>();
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            //執行時可檢視SQL
            dcTrain.Log = new DebuggerWriter();

            //123月第1季，456月第2季....
            //int aa = 0, dd = 0, Season = Convert.ToInt32(cbxSeason.SelectedValue);
            //switch (Season)
            //{
            //    case 1:
            //        aa = 1;
            //        dd = 3;
            //        break;
            //    case 2:
            //        aa = 4;
            //        dd = 6;
            //        break;
            //    case 3:
            //        aa = 7;
            //        dd = 9;
            //        break;
            //    case 4:
            //        aa = 10;
            //        dd = 12;
            //        break;

            //}
            //原無分攤費用寫法
            //var TeacherCost = from m in dcTrain.trTrainingDetailM
            //                  join act in dcTrain.trTrainingActualCost on m.iAutoKey equals act.iClassAutoKey
            //                  join ct in dcTrain.trCostItem on act.trCostItem_sCode equals ct.trCostItemCode
            //                  join ca in dcTrain.trCategory on m.sKey equals ca.sCode
            //                  join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
            //                  join t in dcTrain.trAttendClassTeacher on m.iAutoKey equals t.iClassAutoKey
            //                  join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode
            //                  where ct.trCostItemCode == "4e6592a5-d1a2-40a1-a2c6-03f0ff300564"
            //                  && m.dDateA >= dpA.SelectedDate && m.dDateA <= dpD.SelectedDate //日期區間
            //                  && cbxTeacher.CheckedItems.Select(p1 => p1.Value).Contains(t.sTeacherCode)
            //                  //&& m.dDateA.Value.Month >= aa && m.dDateA.Value.Month <= dd //季
            //                  select new
            //                  {
            //                      Cate = ca.sName,
            //                      Teacher = tea.sName,
            //                      Date = t.dClassDate,
            //                      Course = co.sName,
            //                      CostName = ct.trCostItemName,
            //                      Cost = act.iAmt,
            //                      Hour = m.iCourseTime / 60
            //                  };

            //select * from trTrainingDetailM m
            //join trCategory ca on m.sKey=ca.sCode
            //join trCourse co on m.trCourse_sCode=co.sCode
            //join classteacher t on m.iAutoKey=t.iclassautokey
            //join trTeacher tea on t.sTeacherCode=tea.sCode


            Course CourseDate = new Course();



            //抓mtCode講師費代碼
            mtCode_Repo mtCodeRepo = new mtCode_Repo();
            mtCode mtCodeObj = mtCodeRepo.GetByCategroyCode("Fee", "Instructor");

            if (mtCodeObj == null)
                throw new ApplicationException("尚未設定講師費代碼對應");
            
            var TeacherCost = from m in dcTrain.trTrainingDetailM
                              join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                              join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
                              join t in dcTrain.ClassTeacher on m.iAutoKey equals t.iClassAutoKey
                              join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode
                              join ac in dcTrain.trTrainingActualCost on m.iAutoKey equals ac.iClassAutoKey                              
                              where m.dDateA >= dpA.SelectedDate && m.dDateA <= dpD.SelectedDate
                              && m.trTeacher_sCode == "01" //指定內部講師
                              && m.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                              && cbxTeacher.CheckedItems.Select(p1 => p1.Value).Contains(t.sTeacherCode)
                              && ac.trCostItem_sCode==mtCodeObj.s1
                              select new
                              {
                                  Cate = ca.sName,
                                  Teacher = tea.sName,
                                  //Date = t1.dClassDate,
                                  //Date = Convert.ToDateTime("2012-05-06"),
                                  Date = CourseDate.GetTeacherClassDateByClassTeacher(m.iAutoKey, t.sTeacherCode),
                                  Course = co.sName,
                                  Cost = t.Charge,
                                  //Cost=ac.iAmt,
                                  min = t.Minutes,
                              };

            Reports.TeacherCostDataTable Cost = new Reports.TeacherCostDataTable();

            foreach (var itm in TeacherCost)
            {
                Reports.TeacherCostRow row = Cost.NewTeacherCostRow();

                row.Cate = itm.Cate;
                row.Teacher = itm.Teacher;
                row.Date = itm.Date;
                row.Course = itm.Course;
                //row.Hour = Math.Round(Convert.ToDouble(itm.min / 60), 1, MidpointRounding.AwayFromZero);
                row.Hour = Convert.ToDouble((Decimal)itm.min.Value / 60);                
                row.Cost = Convert.ToInt32(itm.Cost);


                Cost.AddTeacherCostRow(row);

            }

            if (Cost.Rows.Count != 0)
            {
                //取得製表人(登入者)姓名
                var Name = (from c in dcTrain.BASE
                            where c.NOBR == User.Identity.Name
                            select c).FirstOrDefault();

                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("teacherCost", Cost.CopyToDataTable()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (Convert.ToInt32(cbxYear.SelectedValue) - 1911).ToString()));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("Season", cbxSeason.SelectedValue));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("dpA", dpA.SelectedDate.ToString()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("dpD", dpD.SelectedDate.ToString()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Name", Name.NAME_C));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
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