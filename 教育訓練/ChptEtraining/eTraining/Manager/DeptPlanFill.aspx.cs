using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using Repo;
public partial class eTraining_Manager_PlanFill : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);

            //設定已開放填寫需求的年度為預設年度
            trRequirementTemplateRecord_Repo rtrRepo = new trRequirementTemplateRecord_Repo();
            List<trRequirementTemplateRecord> list = rtrRepo.GetByIsClosed(false);
            if (list.Count > 0)
            {
                bool isSelected = false;
                foreach (RadComboBoxItem item in cbxYear.Items)
                {
                    if (item.Value.Equals(list[0].iYear.ToString()))
                    {
                        item.Selected = true;
                        isSelected = true;
                    }
                    else
                        item.Selected = false;
                }

                if (!isSelected)
                {
                    cbxYear.Items[0].Selected = true;
                }
            }
            //bindGvQuest();
            //bindGvQuestCustom();
        }
    }

    private void setPageEnable(bool value)
    {
            gvQuest.Enabled = value; 
            //btnCheck.Enabled = value;
            btnSave.Enabled = value;
    }


    protected void tvDept_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        //bindGvQuest();
        //bindGvQuestCustom();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string msg;

        //將gvQuest的主管需求存入trTrainingQuest
        foreach (GridDataItem itm in gvQuest.Items)
        {
            RadNumericTextBox ntbDemandIntensity = itm["tplDemandIntensity"].FindControl("ntbDemandIntensity") as RadNumericTextBox;

            string key = itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["Id"].ToString();
            var a = (from c in dcTraining.QuestDeptDetail
                     where c.Id == Convert.ToInt32(key)
                     select c).FirstOrDefault();
            if (a != null)
            {
                if ( ntbDemandIntensity.Value.HasValue )
                    a.DemandIntensity = Convert.ToInt32(ntbDemandIntensity.Text);
                else
                    a.DemandIntensity = 0;
                dcTraining.SubmitChanges();
            }
        }

        //將gvQuestCustom的主管需求存入trTrainingQuestCustom
        foreach (GridDataItem item in gvQuestCustom.Items)
        {
            RadNumericTextBox ntbM2 = item["tplDemandIntensity"].FindControl("ntbDemandIntensity") as RadNumericTextBox;

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["Id"].ToString();

            var a = (from c in dcTraining.QuestDeptCustom
                     where c.Id == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if ( a != null )
            {
                if ( ntbM2.Value.HasValue )
                {
                    a.DemandIntensity = Convert.ToInt32(ntbM2.Text);
                }
                else
                    a.DemandIntensity = 0;
                dcTraining.SubmitChanges();
            }
        }

        QuestDept_Repo qdRepo = new QuestDept_Repo();
        QuestDept qdObj= qdRepo.GetByYearDept(Convert.ToInt32(cbxYear.SelectedValue.ToString()), Juser.Dept);
        qdObj.WriteDate = DateTime.Now;
        qdObj.WritedBy = Juser.Nobr;
        qdRepo.Update(qdObj);
        qdRepo.Save();

        RadAjaxPanel1.Alert("已存檔");
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string msg;

        //將gvQuest的主管需求存入trTrainingQuest
        foreach ( GridDataItem itm in gvQuest.Items )
        {
            RadNumericTextBox ntbDemandIntensity = itm["tplDemandIntensity"].FindControl("ntbDemandIntensity") as RadNumericTextBox;

            string key = itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["Id"].ToString();
            var a = (from c in dcTraining.QuestDeptDetail
                     where c.Id == Convert.ToInt32(key)
                     select c).FirstOrDefault();
            if ( a != null )
            {
                a.DemandIntensity = Convert.ToInt32(ntbDemandIntensity.Text);
                dcTraining.SubmitChanges();
            }
        }

        //將gvQuestCustom的主管需求存入trTrainingQuestCustom
        foreach ( GridDataItem item in gvQuestCustom.Items )
        {
            RadNumericTextBox ntbM2 = item["tplDemandIntensity"].FindControl("ntbDemandIntensity") as RadNumericTextBox;

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["Id"].ToString();

            var a = (from c in dcTraining.QuestDeptCustom
                     where c.Id == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if ( a != null )
            {
                if ( ntbM2.Value.HasValue )
                    a.DemandIntensity = Convert.ToInt32(ntbM2.Text);
                else
                    a.DemandIntensity = 0;
                dcTraining.SubmitChanges();
            }

        }
        //bindGvQuest();
        //bindGvQuestCustom();
        RadAjaxPanel1.Alert("已存檔");
    }
    protected void cbxYear_Load(object sender, EventArgs e)
    {
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        checkClosed();
    }

  
    private void checkClosed()
    {
        bool hasSend = false;   //紀碌需求是否送出
        bool isPlanQuestionClosed = false;   //紀碌需求填寫是否關閉(false:未關閉)

        PlanHelper planHelper = new PlanHelper();
        //抓取是否需求填寫是否已關閉(SetPlanQuestionClosed.aspx)
        isPlanQuestionClosed = planHelper.isPlanQuestionClosed(Convert.ToInt32(cbxYear.SelectedValue));

        //如果需求填寫未關閉(isPlanQuestionClosed==False)
        if (!isPlanQuestionClosed)
        {

            //已存入填寫日期，代表已填寫完
            //if (mdate != null)
            //{
            //    hasSend = true;
            //}
        }

        //需求填寫關閉
        if (isPlanQuestionClosed)
        {
            lblMsg.Text = "需求填寫已關閉";
            setPageEnable(false);
        }
        else
        {
            lblMsg.Text = "";
            //將狀態設為可存檔可送出
            setPageEnable(true);
        }
    }

    //private void bindGvQuest()
    //{
    //    sdsQuest.SelectParameters.Clear();
    //    sdsQuest.SelectParameters.Add("Nobr", tvDept.SelectedValue);
    //    sdsQuest.SelectParameters.Add("Year", cbxYear.SelectedValue);
    //    gvQuest.Rebind();
    //}

    //private void bindGvQuestCustom()
    //{
    //    sdsCustom.SelectParameters.Clear();
    //    sdsCustom.SelectParameters.Add("Nobr", tvDept.SelectedValue);
    //    sdsCustom.SelectParameters.Add("Year", cbxYear.SelectedValue);
    //    gvQuestCustom.Rebind();
    //}
    protected void gvQuest_ItemDataBound(object sender, GridItemEventArgs e)
    {
    }
    protected void cbxYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvQuest.Rebind();
        gvQuestCustom.Rebind();
    }

    protected void gvOtherQuest_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
    protected void gvQuest_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        QuestDeptDetail_Repo qddRepo = new QuestDeptDetail_Repo();
        var list=qddRepo.GetByYearDeptCode_Dlo(Convert.ToInt32(cbxYear.SelectedValue.ToString()),Juser.Dept);
        gvQuest.DataSource = (from c in list
                              select new
                              {
                                  c.Id ,
                                  c.DemandIntensity ,
                                  CatName=c.trRequirementTemplateDetail.trRequirementTemplateCat.sName,
                                  CatCode = c.trRequirementTemplateDetail.trRequirementTemplateCat.sCode
                              }).ToList();
    }
    protected void gvQuestCustom_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        QuestDeptCustom_Repo qdcRepo = new QuestDeptCustom_Repo();
        var list= qdcRepo.GetByYearDeptCode(Convert.ToInt32(cbxYear.SelectedValue) , Juser.Dept);
        gvQuestCustom.DataSource = list;
    }
    protected void rbtnAddCourse_Click(object sender , EventArgs e)
    {
        if ( tbCourseName.Text.Trim().Length > 0 )
        {
            QuestDeptCustom obj = new QuestDeptCustom();
            obj.DeptCode = Juser.Dept;
            obj.CourseName = tbCourseName.Text.Trim();
            obj.Year = Convert.ToInt32(cbxYear.SelectedValue.ToString());

            QuestDeptCustom_Repo qdcRepo = new QuestDeptCustom_Repo();
            qdcRepo.Add(obj);
            qdcRepo.Save();
            gvQuestCustom.Rebind();
        }

    }
    protected void gvQuestCustom_InsertCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gvQuestCustom_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("CmdDel"))
        {
            GridDataItem item = e.Item as GridDataItem;
            int id = Convert.ToInt32(item["Id"].Text);

            QuestDeptCustom_Repo qdcRepo = new QuestDeptCustom_Repo();
            var qdcObj = qdcRepo.GetByPk(id);
            qdcRepo.Delete(qdcObj);
            qdcRepo.Save();
            gvQuestCustom.Rebind();
        }
    }
}