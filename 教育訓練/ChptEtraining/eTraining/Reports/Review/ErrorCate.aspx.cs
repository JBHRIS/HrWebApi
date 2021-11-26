using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_ErrorCate : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dpA.SelectedDate = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.Day)) + 1);
            dpD.SelectedDate = DateTime.Now;
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //var ErrorCate = from se in dcTrain.trClassStudentError
        //                join er in dcTrain.trStudentError on se.StudentErrorCode equals er.sCode
        //                where se.dKeyDate >= dpA.SelectedDate && se.dKeyDate <= dpD.SelectedDate
        //                group new { er } by new { er.sName } into gp
        //                select new
        //                {
        //                    Error = gp.Key.sName,
        //                    Total = gp.Key.sName.Count()
        //                };

        //Reports.ErrorCateDataTable error = new Reports.ErrorCateDataTable();

        //foreach (var itm in ErrorCate)
        //{
        //    Reports.ErrorCateRow row = error.NewErrorCateRow();
        //    row.ErrorCate = itm.Error;
        //    row.Total = itm.Total;
        //    error.AddErrorCateRow(row);
        //}

        try
        {
            ClassErrorRpt obj = new ClassErrorRpt();
            Reports.ClassErrorDataTable dt = obj.GetClassErrorBy2Date(dpA.SelectedDate.Value, dpD.SelectedDate.Value);

            if (dt.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt.CopyToDataTable()));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}