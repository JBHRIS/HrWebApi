using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Plan_SetSurveyTemplate2 : System.Web.UI.Page
{
    private dcTrainingDataContext trainingDC = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbYear);

            setPnView();

            //select a.sName from trRequirementTemplate a
            //join trRequirementTemplateRecord b on a.sCode=b.Rt_sCode


        }
        this.Title = "指定調查範本";

    }

    private void setPnView()
    {

        var tp = (from a in trainingDC.trRequirementTemplate
                  join b in trainingDC.trRequirementTemplateRecord on a.sCode equals b.Rt_sCode
                  where b.iYear == Convert.ToInt32(cbYear.SelectedValue)
                  select new { a.sName, a.sCode }).FirstOrDefault();

        if (tp != null)
        {
            lblTp.Text = "已選範本:" + tp.sName;
            lblSelectTpl.Text = tp.sCode;
            gv.Rebind();
        }
        else
        {
            lblSelectTpl.Text = "";
            lblTp.Text = "尚未指定範本";
        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        int year = int.Parse(cbYear.SelectedValue);

        var list = from c in trainingDC.trRequirementTemplateRecord
                   where c.iYear == year
                   select c;

        trainingDC.trRequirementTemplateRecord.DeleteAllOnSubmit(list);

        trRequirementTemplateRecord obj = new trRequirementTemplateRecord();

        obj.iYear = year;
        obj.Rt_sCode = cbTpl.SelectedValue;
        obj.sKeyMan = User.Identity.Name;
        obj.dKeyDate = DateTime.Now;

        trainingDC.trRequirementTemplateRecord.InsertOnSubmit(obj);
        trainingDC.SubmitChanges();

        //TrainingPlan trainingPlan = new TrainingPlan();
        //trainingPlan.setCbYear(cbYear);
        //gv.Rebind();

        //btnSet.Visible = true;
        //gvNowSet.Visible = true;
        //cbTpl.Visible = false;
        //btnCheck.Visible = false;
        //gv.Visible = false;
        setPnView();
        //gvNowSet.Rebind();

        //lblTp.DataBind();

        pnView.Visible = true;
        pnSet.Visible = false;

    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        pnView.Visible = false;
        pnSet.Visible = true;
        cbTpl.DataBind();
        gv.Rebind();
        //cbTpl.Visible = true;
        //btnCheck.Visible = true;
        //gv.Visible = true;
        //btnSet.Visible = false;
        //gvNowSet.Visible = false;
    }
    protected void cbYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var tp = (from a in trainingDC.trRequirementTemplate
                  join b in trainingDC.trRequirementTemplateRecord on a.sCode equals b.Rt_sCode
                  where b.iYear == Convert.ToInt32(cbYear.SelectedValue)
                  select new { a.sName,a.sCode }).FirstOrDefault();

        if (tp != null)
        {
            lblTp.Text = "已選範本:" + tp.sName;
            lblSelectTpl.Text = tp.sCode;
            gvNowSet.Rebind();
        }
        else
        {
            lblSelectTpl.Text = "";
            lblTp.Text = "尚未指定範本";
        }
    }
    protected void cbTpl_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnView.Visible = true;
        pnSet.Visible = false;
    }
}