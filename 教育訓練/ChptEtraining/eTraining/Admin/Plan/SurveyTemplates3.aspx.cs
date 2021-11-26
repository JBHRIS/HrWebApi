using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Admin_Plan_SurveyTemplates3 : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadTabStrip1.SelectedIndex = 0;
            RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;

            SiteHelper sh = new SiteHelper();
            sh.SetTvCourseCat(tvCourse);
            sh.SetTvCourse(tvCourse);
        }

        win.VisibleOnPageLoad = false;
    }



    protected void btnTplAdd_Click(object sender, EventArgs e)
    {
        if ( tbTplName.Text.Trim().Length == 0 )
            return;
        lblMsg.Text = "";
        string sCode = Guid.NewGuid().ToString();
        trRequirementTemplate obj = new trRequirementTemplate();
        obj.sCode = sCode;
        obj.sName = tbTplName.Text;
        obj.dKeyDate = DateTime.Now;
        obj.sKeyMan = User.Identity.Name;

        try
        {
            dcTraining.trRequirementTemplate.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
        }
        catch
        {
            lblMsg.Text = "資料異常，或重複輸入!!";
        }

        gvTemplate.Rebind();

        tbTplName.Text = "";
        cbTplView.DataBind();
    }

    protected void RadTabStrip1_TabClick(object sender , RadTabStripEventArgs e)
    {

    }
    protected void gvTemplate_ItemCommand(object sender , GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        if ( e.CommandName.Equals("cmdEditCourse") )
        {
            pnlCourse.Visible = true;
            lblSelectedTplCode.Text= item["sCode"].Text;
            bind_lbCourse(lblSelectedTplCode.Text);
        }
    }

    private void bind_lbCourse(string tplCode)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList= rtcRepo.GetByRT_CodeDlo(tplCode).OrderBy(p=>p.Sequence).ToList();

        lbCourse.Items.Clear();
        foreach ( var o in rtcList )
        {
            RadListBoxItem item = new RadListBoxItem();
            item.Text = o.trCourse.sName;
            item.Value = o.CourseCode;
            lbCourse.Items.Add(item);
        }
    }

    protected void btnCancel_Click(object sender , EventArgs e)
    {
        pnlCourse.Visible = false;
    }
    protected void btnAddCourse_Click(object sender , EventArgs e)
    {
        foreach ( var p in tvCourse.SelectedNodes )
        {
            if ( !p.Category.Equals("COURSE") )
                continue;

            if ( !lbCourse.Items.Any(i => i.Value == p.Value) )
            {
                RadListBoxItem item = new RadListBoxItem();
                item.Text = p.Text;
                item.Value = p.Value;
                lbCourse.Items.Add(item);
            }
        }        
    }

    protected void btnSaveCourse_Click(object sender , EventArgs e)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(lblSelectedTplCode.Text);

        int i = 0;
        foreach ( RadListBoxItem item in lbCourse.Items )
        {
            trRequirementTemplateCourse obj = (from c in rtcList
                                               where c.CourseCode == item.Value
                                               select c).FirstOrDefault();
            if (obj ==null)
            {
                obj = new trRequirementTemplateCourse();
                obj.Sequence = i;
                obj.RT_Code = lblSelectedTplCode.Text;
                obj.CourseCode = item.Value;
                rtcRepo.Add(obj);
            }
            else
            {
                obj.Sequence = i;
                rtcRepo.Update(obj);
            }
            i++;
        }

        var del_rtcList=(from c in rtcList where !lbCourse.Items.Any(p=>p.Value==c.CourseCode) select c).ToList();

        foreach (var r in del_rtcList)
        {
            rtcRepo.Delete(r);
        }

        rtcRepo.Save();


        pnlCourse.Visible = false;        
    }
    protected void gvTemplate_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        trRequirementTemplate_Repo rtRepo = new trRequirementTemplate_Repo();
        gvTemplate.DataSource = rtRepo.GetAll();
    }
    protected void gvtrRequirementTemplateCourse_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(cbTplView.SelectedValue).OrderBy(p=>p.Sequence).ToList();

        gvtrRequirementTemplateCourse.DataSource = (from c in rtcList
                                                    select new
                                                    {
                                                        c.Id ,
                                                        c.CourseCode ,
                                                        c.Sequence ,
                                                        CourseName = c.trCourse.sName,
                                                        Budget = c.Budget
                                                    }).ToList();
    }

    protected void cbTplView_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvtrRequirementTemplateCourse.Rebind();
    }


    protected void gvtrRequirementTemplateCourse_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvtrRequirementTemplateCourse_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;

        if (e.CommandName.Equals("Select"))
        {
            win.VisibleOnPageLoad = true;
            loadBudget(Convert.ToInt32(item["Id"].Text));
        }
    }

    private void loadBudget(int id)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        var rtcObj = rtcRepo.GetByPk(id);
        ntbBudget.Value = rtcObj.Budget;
    }
    protected void btnBudgetSave_Click(object sender, EventArgs e)
    {
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        var rtcObj = rtcRepo.GetByPk(Convert.ToInt32(gvtrRequirementTemplateCourse.SelectedValue));
        rtcObj.Budget = Convert.ToInt32(ntbBudget.Value);
        rtcRepo.Update(rtcObj);
        rtcRepo.Save();
        gvtrRequirementTemplateCourse.Rebind();
        win.VisibleOnPageLoad = false;
    }
}