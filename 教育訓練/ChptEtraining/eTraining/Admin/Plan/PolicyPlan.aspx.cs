using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class eTraining_Admin_Plan_PolicyPlan : JBWebPage
{
    private dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    private trTrainingPlan_Repo tnPlanRepo = new trTrainingPlan_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);
            loadData();        
        }
    }

    private void loadData()
    {
        int year=DateTime.Now.Year;
        Int32.TryParse(cbxYear.SelectedValue, out year);
        trTrainingPlan tnPlanRecord =  tnPlanRepo.GetByYear(year);
        if (tnPlanRecord == null)
        {
            tnPlanRecord = tnPlanRepo.GetDefault();
            tnPlanRecord.iYear = year;                                    
            tnPlanRepo.dc = dcTrain;
            tnPlanRepo.Add(tnPlanRecord);
            tnPlanRepo.Save();
        }

        cbEditable.Checked = tnPlanRecord.bEditable;
        edtNote.Content = tnPlanRecord.sNote;
        edtGoal.Content = tnPlanRecord.sGoal;
        edtPolicy.Content = tnPlanRecord.sPolicy;
        edtProspect.Content = tnPlanRecord.sProspect;

        edtGoal.Enabled = tnPlanRecord.bEditable;
        edtNote.Enabled = tnPlanRecord.bEditable;
        edtPolicy.Enabled = tnPlanRecord.bEditable;
        edtProspect.Enabled = tnPlanRecord.bEditable;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int year = DateTime.Now.Year;
        Int32.TryParse(cbxYear.SelectedValue, out year);
        trTrainingPlan tnPlanRecord = tnPlanRepo.GetByYear(year);
        if (tnPlanRecord == null)
        {
            tnPlanRecord = tnPlanRepo.GetDefault();
            tnPlanRecord.iYear = year;
            tnPlanRecord.bEditable = cbEditable.Checked;
            tnPlanRecord.sPolicy = edtPolicy.Content;            
            tnPlanRecord.sGoal = edtGoal.Content;
            tnPlanRecord.sNote = edtNote.Content;
            tnPlanRecord.sProspect = edtProspect.Content;
            tnPlanRepo.dc = dcTrain;
            tnPlanRepo.Add(tnPlanRecord);
            tnPlanRepo.Save();
        }
        else
        {
            tnPlanRecord.sPolicy = edtPolicy.Content;
            tnPlanRecord.sGoal = edtGoal.Content;
            tnPlanRecord.sNote = edtNote.Content;
            tnPlanRecord.sProspect = edtProspect.Content;
            tnPlanRecord.bEditable = cbEditable.Checked;
            tnPlanRepo.dc = dcTrain;
            tnPlanRepo.Update(tnPlanRecord);                        
            tnPlanRepo.Save();
        }

        loadData();
    }
    protected void cbxYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        loadData();
    }
    protected void cbEditable_CheckedChanged(object sender, EventArgs e)
    {
        int year=DateTime.Now.Year;
        Int32.TryParse(cbxYear.SelectedValue, out year);
        trTrainingPlan tnPlanRecord =  tnPlanRepo.GetByYear(year);
        tnPlanRecord.bEditable = cbEditable.Checked;
        tnPlanRepo.dc = dcTrain;
        tnPlanRepo.Update(tnPlanRecord);
        tnPlanRepo.Save();
        loadData();
        
    }
}