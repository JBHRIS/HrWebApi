using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_TrainingQuest : JBWebPage
{
    dcTrainingDataContext dc = new dcTrainingDataContext();    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ReportViewer1.Reset();
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbxYear);
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {        
        try
        {
            var Nobr = from c in dc.trTrainingQuest
                       select c.sNobr;

            var TrainingQuest = from tq in dc.trTrainingQuest
                                join ca in dc.trRequirementTemplateCat on tq.sKey equals ca.sCode
                                join co in dc.trCourse on tq.trCourse_sCode equals co.sCode
                                where tq.iYear == Convert.ToInt32(cbxYear.SelectedValue) && tq.sNobr == Nobr.FirstOrDefault()
                                select new
                                {
                                    sKey = ca.sName,
                                    sCode = co.sCode,
                                    sName = co.sName,
                                    idP = "",
                                    idM = ""
                                };
            
            Reports.TrainingQuestDataTable aa = new Reports.TrainingQuestDataTable();

            foreach (var itm in TrainingQuest)
            {
                Reports.TrainingQuestRow row = aa.NewTrainingQuestRow();
                row.sKey = itm.sKey;
                row.trCourse_sName = itm.sName;
                row.trCourse_sCode = itm.sCode;
                row.iDemandIntensityP = itm.idP;
                row.iDemandIntensityM = itm.idM;
                aa.AddTrainingQuestRow(row);
                
            }
            //檢查是否有資料
            if (aa.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/TrainingQuest.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", aa.CopyToDataTable()));
                ReportViewer1.DataBind();
                //ReportViewer1.ZoomMode = ZoomMode.Percent;
                //ReportViewer1.ZoomPercent = 100;
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                throw new Exception("調查表無資料");
            }
            //if (aa.Rows.Count == 0)
            //{                
            //}           
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }

    }
}