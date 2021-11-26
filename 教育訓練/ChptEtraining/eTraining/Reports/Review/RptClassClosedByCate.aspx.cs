using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using Microsoft.Reporting.WebForms;

public partial class eTraining_Reports_Review_RptClassClosedByCate : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    int jobScoreAmt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rdpAdate.SelectedDate = new DateTime(DateTime.Now.Year, 1, 1);
            rdpDdate.SelectedDate = DateTime.Now;
            ntbSession.Text = "1";
        }
    }

    protected void cbxClassCateLevel1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        cbxClassCateLevel2.DataBind();
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        ClassClosedByCate obj = new ClassClosedByCate();
        Reports.ClassClosedByCateDataTable dt = obj.GetData(rdpAdate.SelectedDate.Value, rdpDdate.SelectedDate.Value, Convert.ToInt32(ntbSession.Value), cbxClassCateLevel1.SelectedValue, cbxClassCateLevel2.SelectedValue);

    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            ClassClosedByCate obj = new ClassClosedByCate();
            Reports.ClassClosedByCateDataTable dt = obj.GetData(rdpAdate.SelectedDate.Value, rdpDdate.SelectedDate.Value, Convert.ToInt32(ntbSession.Value), cbxClassCateLevel1.SelectedValue, cbxClassCateLevel2.SelectedValue);
            
            if (dt.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ClassClosedByCate", dt.CopyToDataTable()));
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