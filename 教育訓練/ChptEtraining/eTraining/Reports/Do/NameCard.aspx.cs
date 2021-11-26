using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Microsoft.Reporting.WebForms;
using System.Data;


public partial class eTraining_Reports_Do_NameCard : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper.ConverToChinese(gvCourseList);
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);

            dpStartD.SelectedDate = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.Day)) + 1); //預設篩選條件當月
            dpEndD.SelectedDate = DateTime.Now;
        }
    }
    protected void btnS_Click(object sender, EventArgs e)
    {
        //抓開課編號        
        RadButton btnS = (RadButton)sender;
        lblClassID.Text = btnS.CommandArgument;

        pnlReport.Visible = true;


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
                  //group new { a, c } by new { b.sName, a.sCode, sName1 = a.sName } into gp

                  select new
                  {
                      Student = b.NAME_C,
                      //Dept = dt.D_NAME //部門名稱
                      Dept = dt.D_NO
                      //Dept = tts.DEPT
                  }).ToList();

        Reports.SignTotalDataTable sign = new Reports.SignTotalDataTable();

        foreach (var itm in mm)
        {
            Reports.SignTotalRow row = sign.NewSignTotalRow();
            row.Student = itm.Student;
            row.Dept = itm.Dept;
            sign.AddSignTotalRow(row);
        }

        if (sign.Rows.Count != 0)
        {
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Do/NameCard.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sign.CopyToDataTable()));

            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.Refresh();
        }
        else
        {
            AlertMsg("無設定學員");
        }
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        RadButton btn1 = (RadButton)sender;
        lblClassID.Text = btn1.CommandArgument;

        pnlS.Visible = false;
        pnlReport.Visible = false;
        pnlN.Visible = false;
        pnlF.Visible = true;

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
                  //group new { a, c } by new { b.sName, a.sCode, sName1 = a.sName } into gp

                  select new
                  {
                      Student = b.NAME_C,
                      Dept = dt.D_NO

                      //Dept = tts.DEPT
                  }).ToList();

        Reports.SignTotalDataTable sign = new Reports.SignTotalDataTable();

        foreach (var itm in mm)
        {
            Reports.SignTotalRow row = sign.NewSignTotalRow();
            row.Student = itm.Student;
            row.Dept = itm.Dept;
            sign.AddSignTotalRow(row);
        }

        if (sign.Rows.Count != 0)
        {
            ReportViewer3.Reset();
            ReportViewer3.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Do/NameCardF.rdlc");
            ReportViewer3.LocalReport.DataSources.Clear();

            ReportViewer3.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sign.CopyToDataTable()));

            ReportViewer3.DataBind();
            ReportViewer3.LocalReport.Refresh();
        }
        else
        {
            AlertMsg("無設定學員");
        }
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        RadButton btn2 = (RadButton)sender;
        lblClassID.Text = btn2.CommandArgument;

        pnlReport.Visible = false;
        pnlS.Visible = true;
        pnlF.Visible = false;
        pnlN.Visible = false;

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
                  //group new { a, c } by new { b.sName, a.sCode, sName1 = a.sName } into gp

                  select new
                  {
                      Student = b.NAME_C,
                      Dept = dt.D_NO

                      //Dept = tts.DEPT
                  }).ToList();

        Reports.SignTotalDataTable sign = new Reports.SignTotalDataTable();

        foreach (var itm in mm)
        {
            Reports.SignTotalRow row = sign.NewSignTotalRow();
            row.Student = itm.Student;
            row.Dept = itm.Dept;
            sign.AddSignTotalRow(row);
        }

        if (sign.Rows.Count != 0)
        {
            ReportViewer2.Reset();
            ReportViewer2.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Do/NameCardS.rdlc");
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sign.CopyToDataTable()));
            ReportViewer2.DataBind();
            ReportViewer2.LocalReport.Refresh();
        }
        else
        {
            AlertMsg("無設定學員");
        }
    }
    protected void btn3_Click(object sender, EventArgs e)
    {
        RadButton btn3 = (RadButton)sender;
        lblClassID.Text = btn3.CommandArgument;

        pnlReport.Visible = false;
        pnlS.Visible = false;
        pnlF.Visible = false;
        pnlN.Visible = true;

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
                  //group new { a, c } by new { b.sName, a.sCode, sName1 = a.sName } into gp

                  select new
                  {
                      Student = b.NAME_C,
                      Dept = dt.D_NO

                      //Dept = tts.DEPT
                  }).ToList();

        Reports.SignTotalDataTable sign = new Reports.SignTotalDataTable();

        foreach (var itm in mm)
        {
            Reports.SignTotalRow row = sign.NewSignTotalRow();
            row.Student = itm.Student;
            row.Dept = itm.Dept;
            sign.AddSignTotalRow(row);
        }

        if (sign.Rows.Count != 0)
        {
            ReportViewer4.Reset();
            ReportViewer4.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Do/NameCardN.rdlc");
            ReportViewer4.LocalReport.DataSources.Clear();

            ReportViewer4.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sign.CopyToDataTable()));

            ReportViewer4.DataBind();
            ReportViewer4.LocalReport.Refresh();
        }
        else
        {
            AlertMsg("無設定學員");
        }
    }
}