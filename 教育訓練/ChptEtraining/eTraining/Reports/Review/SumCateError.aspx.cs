using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_SumCateError : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dpA.SelectedDate = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.Day)) + 1);
            dpD.SelectedDate = DateTime.Now.AddDays(1);
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            //select ca.sName,e.sName,count(e.sName) from trClassStudentError se
            //join trStudentError e on se.StudentErrorCode=e.sCode
            //join trTrainingDetailM m on se.iClassAutoKey=m.iAutoKey
            //join trCategory ca on m.sKey=ca.sCode
            //where se.dKeyDate between '2011-11-20' and '2011-11-23'
            //group by ca.sName,e.sName
            //order by ca.sName
            var CateError = from se in dcTrain.trClassStudentError
                            join er in dcTrain.trStudentError on se.StudentErrorCode equals er.sCode
                            join m in dcTrain.trTrainingDetailM on se.iClassAutoKey equals m.iAutoKey
                            join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                            where se.dKeyDate >= dpA.SelectedDate && se.dKeyDate <= dpD.SelectedDate
                            group new { ca, er } by new { Cate = ca.sName, ErrName = er.sName } into gp
                            select new
                            {
                                Cate = gp.Key.Cate,
                                ErrName = gp.Key.ErrName,
                                aa = gp.Key.ErrName.Count()                                
                            };

            Reports.SumCateErrorDataTable error = new Reports.SumCateErrorDataTable();

            foreach (var itm in CateError)
            {
                Reports.SumCateErrorRow row = error.NewSumCateErrorRow();

                row.Cate = itm.Cate;
                row.Detail1 = itm.ErrName;
                row.Detail2 = itm.aa;

                error.AddSumCateErrorRow(row);
            }

            if (error.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", error.CopyToDataTable()));
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