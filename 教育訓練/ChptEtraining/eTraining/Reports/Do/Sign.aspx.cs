using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Do_Sign : JBWebPage
{
    const int NUM_OF_PAGE = 30;
    const int HALF_NUM_OF_PAGE = 15;
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvCourseList);
        
        if (!IsPostBack)
        {
            PlanHelper helper = new PlanHelper();
            helper.setCbYear(cbxYear);
            helper.getLastPlanYear();
            dpStartD.SelectedDate = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.Day)) + 1); //預設篩選條件當月
            dpEndD.SelectedDate = DateTime.Now;
        }

    }
    protected void btnS_Click(object sender, EventArgs e)
    {
        pnlDate.Visible = true;
        pnlCourseList.Visible = false;
        //抓開課編號
        RadButton btnS = (RadButton)sender;
        lblClassID.Text = btnS.CommandArgument;
        cbxClassDate.DataBind();

        //抓課程名稱
        var CourseName = (from a in dcTrain.trTrainingDetailM
                          join b in dcTrain.trCourse on a.trCourse_sCode equals b.sCode
                          where a.iAutoKey == Convert.ToInt32(lblClassID.Text)
                          select b.sName).FirstOrDefault();
        lblCourseName.Text = CourseName;


    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        pnlReport.Visible = true;

        try
        {
            dcTrain.Log = Console.Out;

            var mm = (from p in dcTrain.trTrainingStudentPresence
                      join d in dcTrain.trAttendClassDate on p.AttendClassDateID equals d.iAutoKey
                      join tm in dcTrain.trTrainingStudentM on p.trTrainingStudentM_ID equals tm.iAutoKey
                      join b in dcTrain.BASE on tm.sNobr equals b.NOBR
                      join tts in dcTrain.BASETTS on b.NOBR equals tts.NOBR
                      join dt in dcTrain.DEPT on tts.DEPT equals dt.D_NO //查詢部門名稱
                      
                      where p.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                      && new string[] { "1", "4", "6" }.Contains(tts.TTSCODE)
                      && tts.ADATE <= DateTime.Today && tts.DDATE >= DateTime.Today
                          //&& dt.ADATE <= DateTime.Today && dt.DDATE >= DateTime.Today //檢查部門名稱是否重覆
                      && d.dClassDate == Convert.ToDateTime(cbxClassDate.SelectedItem.Text)
                      orderby dt.D_NO
                      select new
                      {
                          Student = b.NAME_C,
                          Dept = dt.D_NO, //部門名稱
                          //Dept = tts.DEPT
                          sNote3=tm.sNote3 //加備註 2013/4/24新增需求
                      }).ToList();



            //抓取課程資料
            var CourseDetail = (from m in dcTrain.trTrainingDetailM
                                join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
                                join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                                join d in dcTrain.trAttendClassDate on m.iAutoKey equals d.iClassAutoKey
                                join t in dcTrain.trAttendClassTeacher on m.iAutoKey equals t.iClassAutoKey
                                join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode
                                join p in dcTrain.trAttendClassPlace on m.iAutoKey equals p.iClassAutoKey
                                join pla in dcTrain.trClassroom on p.sPlaceCode equals pla.sCode
                                where m.iAutoKey == Convert.ToInt32(lblClassID.Text)
                                && d.dClassDate >= dpStartD.SelectedDate && d.dClassDate <= dpEndD.SelectedDate  //篩選日期區間

                                select new
                               {
                                   date = d.dClassDate,
                                   timeA = d.dClassDateA,
                                   timeD = d.dClassDateD,
                                   cate = ca.sName,
                                   course = co.sName,
                                   teacher = tea.sName,
                                   place = pla.sName,
                                   //student = b.NAME_C,
                                   //dept = bt.DEPT
                               }).FirstOrDefault();
            if (CourseDetail == null)
            {
                AlertMsg("資料錯誤");
                return;
            }
            //課程資料
            string date = CourseDetail.date.ToString();
            string cate = CourseDetail.cate;
            DateTime timeA = Convert.ToDateTime(CourseDetail.timeA);
            DateTime timeD = Convert.ToDateTime(CourseDetail.timeD);
            string teacher = CourseDetail.teacher;
            string place = CourseDetail.place;





            //Reports.SignTitleDataTable signTitle = new Reports.SignTitleDataTable();
            //課程資料DT
            //foreach (var itm in CourseDetail)
            //{
            //    Reports.SignTitleRow row = signTitle.NewSignTitleRow();
            //    row.Cate = itm.cate;
            //    row.Course = itm.course;
            //    //row.Date = itm.date;
            //    row.Date = Convert.ToDateTime(cbxClassDate.Text);
            //    row.Time1 = Convert.ToDateTime(itm.timeA);
            //    row.Time2 = Convert.ToDateTime(itm.timeD);
            //    row.Teacher = itm.teacher;
            //    row.Classroom = itm.place;

            //    signTitle.AddSignTitleRow(row);
            //}



            Reports.SignTotalDataTable sign = new Reports.SignTotalDataTable();

            //取得總筆數DT
            foreach (var itm in mm)
            {
                Reports.SignTotalRow row = sign.NewSignTotalRow();
                row.Student = itm.Student;
                row.Dept = itm.Dept;
                row.sNote3 = itm.sNote3;
                
                sign.AddSignTotalRow(row);
            }

           

            //補到30的倍數
            int quotient = sign.Rows.Count / NUM_OF_PAGE;
            int printAmt = (quotient + 1) * NUM_OF_PAGE;
            int half_printAmt = printAmt / 2;

            Reports.SignTotalDataTable stDT = new Reports.SignTotalDataTable();

            while (sign.Rows.Count <= printAmt)
            {
                Reports.SignTotalRow row = sign.NewSignTotalRow();
                //Reports.SignTotalRow row  = stDT.NewSignTotalRow();
                row.Student = " ";
                row.Dept = " ";
                sign.AddSignTotalRow(row);
            }


            Reports.SignTotalDataTable sign1 = new Reports.SignTotalDataTable();
            Reports.SignTotalDataTable sign2 = new Reports.SignTotalDataTable();

            for (int i = 0; i < printAmt; i++)
            {
                //Reports.SignTotalRow row = sign.NewSignTotalRow();
                //Reports.SignTotalRow row= sign1.NewSignTotalRow();


                if (i % 2 == 0)
                {
                    Reports.SignTotalRow row = sign1.NewSignTotalRow();
                    row.Student = sign.Rows[i]["Student"].ToString();
                    row.Dept = sign.Rows[i]["Dept"].ToString();
                    row.sNote3 = sign.Rows[i]["sNote3"].ToString();
                    sign1.Rows.Add(row);
                    //  sign1.Rows.RemoveAt(i);
                }
                else
                {
                    Reports.SignTotalRow row = sign2.NewSignTotalRow();
                    row.Student = sign.Rows[i]["Student"].ToString();
                    row.Dept = sign.Rows[i]["Dept"].ToString();
                    row.sNote3 = sign.Rows[i]["sNote3"].ToString();
                    sign2.Rows.Add(row);
                }

            }

            //Reports.Sign1DataTable sign1 = new Reports.Sign1DataTable();

            //Reports.Sign2DataTable signBlank = new Reports.Sign2DataTable();

            //int j = 0;

            //foreach (var itm in mm)
            //{
            //    if (mm.Count > 15)
            //    {
            //        if (j < 15)
            //        {
            //            Reports.SignTotalRow row = sign.NewSignTotalRow();
            //            row.Student = itm.Student;
            //            row.Dept = itm.Dept;
            //            sign.AddSignTotalRow(row);

            //            j++;
            //        }
            //        else
            //        {
            //            //Sign DateTable (DataSet1)

            //            //Reports.SignRow row = sign.NewSignRow();
            //            ////row.Student = itm.Student;
            //            ////row.Dept = itm.Dept;
            //            //row.Student = "";
            //            //row.Dept = "";
            //            //sign.AddSignRow(row);


            //            //Sign1 DataTable (DataSet2)                        
            //            //Show("資料筆數大於15");
            //            //Reports.Sign1Row row1 = sign1.NewSign1Row();
            //            //row1.Student = itm.Student;
            //            //row1.Dept = itm.Dept;

            //            //sign1.AddSign1Row(row1);

            //        }
            //    }
            //    else
            //    {
            //        Reports.SignTotalRow row = sign.NewSignTotalRow();
            //        row.Student = itm.Student;
            //        row.Dept = itm.Dept;
            //        sign.AddSignTotalRow(row);









            //        //Sign1 DataTable (DataSet2)
            //       // Reports.Sign1Row row1 = sign1.NewSign1Row();
            //        //row1.Student = "";
            //        //row1.Dept = "";

            //        //sign1.AddSign1Row(row1);
            //    }

            //}
            //DATASET3加入空白
            //if (mm.Count < 15)
            //{
            //    for (int k = 0; k < 15 - mm.Count; k++)
            //    {

            //        Reports.Sign2Row rowBlank = signBlank.NewSign2Row();
            //        rowBlank.dept = "";
            //        rowBlank.student = "";
            //        signBlank.AddSign2Row(rowBlank);
            //    }
            //}

            //檢查是否有資料
            if (sign.Rows.Count == 0)
            {
                AlertMsg("無訓練學員");
                pnlReport.Visible = false;
            }
            else
            {

                ReportViewer1.Reset();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Do/Sign.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.ZoomMode = ZoomMode.Percent;
                ReportViewer1.ZoomPercent = 100;
                //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);



                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sign1.CopyToDataTable()));

                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SignTitle", signTitle.CopyToDataTable()));


                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", sign2.CopyToDataTable()));

                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", signBlank.CopyToDataTable()));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", cbxYear.SelectedValue));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Course", lblCourseName.Text));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("date", date.Substring(0, 10)));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Cate", cate));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("timeA", timeA.TimeOfDay.ToString()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("timeD", timeD.TimeOfDay.ToString()));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("timeD", timeD.Substring(12, 6)));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("teacher", teacher));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("place", place));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }

        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlCourseList.Visible = true;
        pnlDate.Visible = false;
        pnlReport.Visible = false;
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        gvCourseList.Visible = true;
        gvCourseList.DataBind();
    }

}