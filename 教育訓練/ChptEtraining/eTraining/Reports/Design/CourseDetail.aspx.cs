using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Repo;
using Telerik.Web.UI;
public partial class eTraining_Reports_Design_CourseDetail : JBWebPage
{
    private class Rpt
    {
        public int iAutoKey { get; set; }
        public int iClassAutoKey { get; set; }
        public DateTime ClassAttendDate { get; set; }
        public string ClassAttendDateTime { get; set; }
        public string ClassCat { get; set; }
        public string ClassName { get; set; }
        public string Teacher { get; set; }
        public string Place { get; set; }
        public string TrainingMethod { get; set; }
        public string Student { get; set; }
        public int Cost { get; set; }
    }

    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);
            this.Title = "課程資料";

            dpStartD.SelectedDate = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.Day)) + 1); //預設篩選條件當月
            dpEndD.SelectedDate = DateTime.Now;

            //講師預設CheckAllItem
            //cbxTeacher.SelectedIndex = 0;
            //cbxTeacher.CheckedItems 
            
            
        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> tdmList= tdmRepo.GetByDateRangePublished_DLO(dpStartD.SelectedDate.Value, dpEndD.SelectedDate.Value);

        IEnumerable<string> selectedTeacher = cbxTeacher.CheckedItems.Select(p=>p.Value).ToList();

        List<Rpt> rptList = new List<Rpt>();
        foreach (var tdm in tdmList)
        {
            IEnumerable<string> vl = tdm.ClassTeacher.AsEnumerable().Select(p => p.sTeacherCode).Intersect(selectedTeacher);
            //確定有含該講師
            if (vl.Count() > 0)
            {
                foreach (var t in tdm.trAttendClassDate)
                {
                    Rpt rpt = new Rpt();
                    rpt.iAutoKey = t.iAutoKey;
                    rpt.iClassAutoKey = t.iClassAutoKey;
                    rpt.Place = t.trAttendClassPlace.trClassroom.sName;
                    rpt.TrainingMethod = t.trTrainingDetailM.trTrainingMethod.sName;
                    rpt.Teacher = "";
                    foreach(var a in t.trTrainingDetailM.ClassTeacher)
                    {
                        rpt.Teacher = rpt.Teacher + a.trTeacher.sName + "、";
                    }

                    if (rpt.Teacher.Length > 0)
                        if (rpt.Teacher[rpt.Teacher.Length - 1].Equals('、'))
                            rpt.Teacher=rpt.Teacher.Remove(rpt.Teacher.Length - 1);

                    rpt.Student = "";
                    foreach(var b in t.trTrainingDetailM.trTrainingStudentM)
                    {
                        rpt.Student = rpt.Student + b.BASE.NAME_C+"、";
                    }

                    if (rpt.Student.Length > 0)
                        if (rpt.Student[rpt.Student.Length - 1].Equals('、'))
                            rpt.Student=rpt.Student.Remove(rpt.Student.Length - 1);


                    rpt.ClassAttendDate = t.dClassDate.Date;
                    rpt.ClassAttendDateTime = t.dClassDateA.Value.ToString("HH:mm") + "-" + t.dClassDateD.Value.ToString("HH:mm");
                    rpt.ClassName = t.trTrainingDetailM.trCourse.sName;
                    rpt.ClassCat = t.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName;
                    rpt.Cost = t.trTrainingDetailM.iActualAMT;
                    rptList.Add(rpt);
                }
            }
        }

        gv.DataSource = rptList;
        gv.Rebind();

        //20130802廣祺註解掉，因下方的查詢資料會有問題，不好，改用GridView 做
        //try
        //{
        //    var CourseDetail = from m in dcTrain.trTrainingDetailM
        //                       join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
        //                       join ca in dcTrain.trCategory on m.sKey equals ca.sCode
        //                       join d in dcTrain.trAttendClassDate on m.iAutoKey equals d.iClassAutoKey
        //                       join t in dcTrain.trAttendClassTeacher on m.iAutoKey equals t.iClassAutoKey
        //                       join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode
        //                       join p in dcTrain.trAttendClassPlace on m.iAutoKey equals p.iClassAutoKey
        //                       join pla in dcTrain.trClassroom on p.sPlaceCode equals pla.sCode
        //                       //join meth in dcTrain.trTrainingMethod on m.trTrainingMethod_sCode equals meth.sCode                               
        //                       join std in dcTrain.trTrainingStudentM on m.iAutoKey equals std.iClassAutoKey
        //                       join b in dcTrain.BASE on std.sNobr equals b.NOBR
        //                       join bt in dcTrain.BASETTS on b.NOBR equals bt.NOBR
        //                       join method in dcTrain.trTrainingMethod on m.trTrainingMethod_sCode equals method.sCode
        //                       where m.iYear == Convert.ToInt32(cbxYear.SelectedValue)
        //                           //&& m.dDateA.Value.Month == Convert.ToInt32(cbxMonth.SelectedValue)  //篩選月份
        //                           //&& t.sTeacherCode == cbxTeacher.SelectedValue
        //                       && cbxTeacher.CheckedItems.Select(p1 => p1.Value).Contains(t.sTeacherCode)  //篩選講師                               
        //                           //&& TeacherCodes.Contains(t.sTeacherCode)
        //                       && m.bIsPublished == true //已發佈之課程
        //                       && d.dClassDate >= dpStartD.SelectedDate && d.dClassDate <= dpEndD.SelectedDate  //篩選日期區間
        //                       && bt.ADATE <= DateTime.Today && bt.DDATE >= DateTime.Today
        //                       && new string[] { "1", "4", "6" }.Contains(bt.TTSCODE)
        //                       select new
        //                       {
        //                           classId=m.iAutoKey,
        //                           date = d.dClassDate,
        //                           timeA = d.dClassDateA,
        //                           timeD = d.dClassDateD,
        //                           cate = ca.sName,
        //                           course = co.sName,
        //                           teacher = tea.sName,
        //                           place = pla.sName,
        //                           student = b.NAME_C,
        //                           //trainingType = meth.sName,
        //                           cost = m.iEstimateAMT, //開課所key入的預估費用(非年度計劃)
        //                           method = method.sName,
        //                           dept = bt.DEPT
        //                       };

        //    Reports.CourseDetailDataTable courseDetail = new Reports.CourseDetailDataTable();

        //    trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();

        //    foreach (var itm in CourseDetail)
        //    {
        //        Reports.CourseDetailRow row = courseDetail.NewCourseDetailRow();

        //        var rep = courseDetail.FindByDate(itm.date);
        //        if (rep != null)
        //        {
        //            //rep.Student += itm.dept + itm.student + "、";
        //        }
        //        else
        //        {
        //            row.Date = Convert.ToDateTime(itm.date);
        //            row.TimeA = Convert.ToDateTime(itm.timeA);
        //            row.TimeD = Convert.ToDateTime(itm.timeD);
        //            row.Cate = itm.cate;
        //            row.Course = itm.course;
        //            row.Teacher = itm.teacher;
        //            row.Place = itm.place;
        //            row.Student = tsmRepo.GetDeptStudentStringByClassId(itm.classId);
        //            //row.TrainingType = itm.method.Substring(0, 1); //"內"訓，只顯示第一個字
        //            row.TrainingType = itm.method;
        //            row.Cost = itm.cost;

        //            courseDetail.AddCourseDetailRow(row);
        //        }
        //    }
        //    //取得登入者姓名
        //    var Name = (from c in dcTrain.BASE
        //                where c.NOBR == User.Identity.Name
        //                select c).FirstOrDefault();

        //    if (courseDetail.Rows.Count != 0)
        //    {
        //        ReportViewer1.Reset();
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Design/CourseDetail.rdlc");
        //        ReportViewer1.LocalReport.DataSources.Clear();
        //        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", courseDetail.CopyToDataTable()));
        //        ReportViewer1.LocalReport.SetParameters(new ReportParameter("Name", Name.NAME_C));
        //        ReportViewer1.DataBind();
        //        ReportViewer1.LocalReport.Refresh();
        //    }
        //    else
        //    {
        //        throw new Exception("無資料");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    AlertMsg(ex.Message);
        //}
    }


    protected void gv_PreRender(object sender, EventArgs e)
    {
        for (int rowIndex = gv.Items.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridDataItem row = gv.Items[rowIndex];
            GridDataItem previousRow = gv.Items[rowIndex + 1];
            if (row["iClassAutoKey"].Text == previousRow["iClassAutoKey"].Text)
            {
                row["ClassCat"].RowSpan = previousRow["ClassCat"].RowSpan < 2 ? 2 : previousRow["ClassCat"].RowSpan + 1;
                previousRow["ClassCat"].Visible = false;
                row["ClassName"].RowSpan = previousRow["ClassName"].RowSpan < 2 ? 2 : previousRow["ClassName"].RowSpan + 1;
                previousRow["ClassName"].Visible = false;
                row["Teacher"].RowSpan = previousRow["Teacher"].RowSpan < 2 ? 2 : previousRow["Teacher"].RowSpan + 1;
                previousRow["Teacher"].Visible = false;
                row["TrainingMethod"].RowSpan = previousRow["TrainingMethod"].RowSpan < 2 ? 2 : previousRow["TrainingMethod"].RowSpan + 1;
                previousRow["TrainingMethod"].Visible = false;
                row["Student"].RowSpan = previousRow["Student"].RowSpan < 2 ? 2 : previousRow["Student"].RowSpan + 1;
                previousRow["Student"].Visible = false;
                row["Cost"].RowSpan = previousRow["Cost"].RowSpan < 2 ? 2 : previousRow["Cost"].RowSpan + 1;
                previousRow["Cost"].Visible = false;
            }
        } 
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        gv.ExportSettings.ExportOnlyData = false;
        gv.ExportSettings.HideStructureColumns = false;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = Server.UrlEncode("月份課程安排表");
        gv.MasterTableView.ExportToExcel();
    }
}