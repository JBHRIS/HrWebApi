using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_JobScoreGoal : JBWebPage
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
        //var AjobScore = from c in dcTrain.trOJTStudentD
        //                where c.OJT_sCode == cbxOjt.SelectedValue && c.dFinalCheckDate <= Convert.ToDateTime("2011/09/31")                        
        //                group new { c } by new { c.iJobScore } into gp
        //                let sum = gp.Sum(p => p.c.iJobScore)
        //                select sum;
        try
        {
            JobAbility obj = new JobAbility();
            Reports.JobAbilityDataTable dt = obj.GetDataByCardYear(cbxOjt.SelectedValue, Convert.ToInt32(cbxYear.SelectedValue));

            if (dt.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt.CopyToDataTable()));
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