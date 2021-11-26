using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_RptCourseReviewB : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {

        //var eCourseB = from m in dcTrain.trTrainingDetailM
        //               join co in dcTrain.trCourse on m.sKey equals co.sCode
        //               join ca in dcTrain.trCategory on m.sKey equals ca.sCode
        //               join sd in dcTrain.trTrainingStudentM on m.iAutoKey equals sd.iClassAutoKey
        //               join b in dcTrain.BASE on sd.sNobr equals b.NOBR
        //               where ca.sParentCode == "B"
        //               select new
        //               {
        //                   Cate = ca.sName,
        //                   StudentList = b.NAME_C,
        //                   SudentNum = m.iStudentNum
        //               };

        //Reports.CourseReviewBDataTable CourseB = new Reports.CourseReviewBDataTable();
        //foreach (var itm in eCourseB)
        //{
        //    Reports.CourseReviewBRow row = CourseB.NewCourseReviewBRow();
        //    row.Cate = itm.Cate;
        //    //row.ePeople = itm.SudentNum.ToString();

        //    CourseB.AddCourseReviewBRow(row);

        //}

        try
        {
            SpecialClass sClass = new SpecialClass();
            Reports.CourseReviewBDataTable dt = sClass.GetData("B", Convert.ToInt32(cbxYear.SelectedValue));

            if (dt.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.CopyToDataTable()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (Convert.ToInt32(cbxYear.SelectedValue) - 1911).ToString()));
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