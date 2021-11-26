using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_DeptCateError : JBWebPage
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
        try
        {
            //select tts.DEPT,count(se.iClassAutoKey) from trClassStudentError se
            //join trStudentError e on se.StudentErrorCode=e.sCode
            //join BASETTS tts on se.sNobr=tts.NOBR
            //where se.dKeyDate between '2011-11-20' and '2011-11-23'
            //and CONVERT(varchar(10), GETDATE(),111) between ADATE and DDATE
            //and TTSCODE in('1','4','6')
            //group by tts.DEPT

            var CateError = from se in dcTrain.trClassStudentError
                            join er in dcTrain.trStudentError on se.StudentErrorCode equals er.sCode
                            join tts in dcTrain.BASETTS on se.sNobr equals tts.NOBR
                            where se.dKeyDate >= dpA.SelectedDate && se.dKeyDate <= dpD.SelectedDate
                            && DateTime.Now >= tts.ADATE && DateTime.Now <= tts.DDATE
                            && new string[] { "1", "4", "6" }.Contains(tts.TTSCODE)
                            group new { tts } by new { tts.DEPT } into gp
                            select new
                            {
                                Dept = gp.Key.DEPT,
                                ErrorNum = gp.Key.DEPT.Count()
                            };
            Reports.DeptCateErrorDataTable error = new Reports.DeptCateErrorDataTable();

            foreach (var itm in CateError)
            {
                Reports.DeptCateErrorRow row = error.NewDeptCateErrorRow();
                row.dept = itm.Dept.ToString();

                row.errorNum = Convert.ToInt32(itm.ErrorNum);

                error.AddDeptCateErrorRow(row);
            }
            if (error.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", error.CopyToDataTable()));
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