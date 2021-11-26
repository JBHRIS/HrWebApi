using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_RptCourseReviewA : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);
            this.Title = "年度計畫檢討";
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        CoreClassRpt courseReview = new CoreClassRpt();
        List<CoreClassRpt> list = courseReview.GetData(cbxCate.SelectedValue, Convert.ToInt32(cbxYear.SelectedValue));

        Reports.CourseReviewADataTable ReviewA = new Reports.CourseReviewADataTable();

        try
        {
            foreach (var itm in list)
            {
                Reports.CourseReviewARow row = ReviewA.NewCourseReviewARow();

                //2013/05/27-判斷計畫目標-開課梯次、人次、費用，實際開課-開課梯次、人次、費用為0的不顯示
                if (itm.計畫開課梯次 == 0 && itm.計畫人次 == 0 && itm.計畫費用 == 0 && itm.實際開課梯次 == 0 && itm.實際人次 == 0 && itm.實際費用 == 0)
                {
                }
                else
                {
                    row.eSession = itm.計畫開課梯次;
                    row.aSession = itm.實際開課梯次;
                    //row.dSession = itm.差異開課梯次;
                    row.Key = itm.課程名稱;
                    row.ePeople = itm.計畫人次;
                    row.aPeople = itm.實際人次;
                    //row.dPeople = itm.差異人次;
                    row.eAmt = itm.計畫費用;
                    row.aAmt = itm.實際費用;
                    //row.dAmt = itm.差異費用;                
                    row.CourseRate = itm.開課達成率;
                    row.PeopleRate = itm.培育達成率;

                    ReviewA.AddCourseReviewARow(row);
                }
            }

            if (ReviewA.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ReviewA.CopyToDataTable()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (Convert.ToInt32(cbxYear.SelectedValue) - 1911).ToString()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Cate", cbxCate.Text));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                throw new Exception("無可查閱資料");
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}