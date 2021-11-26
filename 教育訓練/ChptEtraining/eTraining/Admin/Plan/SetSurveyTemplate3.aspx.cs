using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class eTraining_Admin_Plan_SetSurveyTemplate3 : JBWebPage
{
    private dcTrainingDataContext trainingDC = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbYear);

            setPnView();
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
            gvNowSet.Rebind();
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

        setPnView();

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
    protected void gv_NeedDataSource(object sender , Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(cbTpl.SelectedValue).OrderBy(p => p.Sequence).ToList();

        gv.DataSource = (from c in rtcList
                         select new
                         {
                             c.Id ,
                             c.CourseCode ,
                             c.Sequence ,
                             CourseName = c.trCourse.sName ,
                             Budget = c.Budget
                         }).ToList();
    }
    protected void gvNowSet_NeedDataSource(object sender , Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(lblSelectTpl.Text).OrderBy(p => p.Sequence).ToList();

        gvNowSet.DataSource = (from c in rtcList
                         select new
                         {
                             c.Id ,
                             c.CourseCode ,
                             c.Sequence ,
                             CourseName = c.trCourse.sName,
                             Budget = c.Budget
                         }).ToList();
    }
}