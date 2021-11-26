using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using Repo;
public partial class eTraining_Manager_PlanFill3 : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    private void bindTrainingMethod()
    {
        var mList = (from c in dcTraining.trTrainingMethod select c).ToList();
        foreach (var m in mList)
        {
            RadComboBoxItem i = new RadComboBoxItem();
            i.Value = m.sCode;
            i.Text = m.sName;
            cbTrainingMethod.Items.Add(i);

            RadComboBoxItem i2 = new RadComboBoxItem();
            i2.Value = m.sCode;
            i2.Text = m.sName;
            cbCusTrainingMethod.Items.Add(i2);
        }
    }




    private void bindSuggestionPassItem()
    {
        var list = (from c in dcTraining.trKnotTeaches select c).ToList();
        foreach (var m in list)
        {
            RadComboBoxItem i = new RadComboBoxItem();
            i.Value = m.KnotTeachesCode;
            i.Text = m.KnotTeachesName;
            cbxSuggestionPassItem.Items.Add(i);

            RadComboBoxItem i2 = new RadComboBoxItem();
            i2.Value = m.KnotTeachesCode;
            i2.Text = m.KnotTeachesName;
            cbxCusSuggestionPassItem.Items.Add(i2);
        }
    }

    private void setControlEnable(int year)
    {
        trRequirementTemplateRecord_Repo rtrRepo = new trRequirementTemplateRecord_Repo();
        trRequirementTemplateRecord rtrObj = rtrRepo.GetByYear(year);
        if (rtrObj != null)
        {
            gvQuest.Enabled = rtrObj.bIsClosed;
            gvQuestCustom.Enabled = rtrObj.bIsClosed;
            rbtnAddCourse.Enabled = rtrObj.bIsClosed;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper sh = new SiteHelper();
            sh.InitManagerDeptTreeView(tvDept, Juser.ManageDeptRootNodeList);

            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);

            bindTrainingMethod();
            bindSuggestionPassItem();
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

        winQuest.VisibleOnPageLoad = false;
        winCus.VisibleOnPageLoad = false;
        winOuter.VisibleOnPageLoad = false;
    }

    private void setPageEnable(bool value)
    {
        gvQuest.Enabled = value;
        gvQuestCustom.Enabled = value;
        rbtnAddCourse.Enabled = value;
    }


    protected void tvDept_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        if (Juser.ManageDeptRootNodeList.Select(p => p.Value).Any(c => c == tvDept.SelectedValue))
        {
            gvQuest.MasterTableView.GetColumn("cmdReject").Visible = false;
            gvQuestCustom.MasterTableView.GetColumn("cmdReject").Visible = false;
        }
        else
        {
            gvQuest.MasterTableView.GetColumn("cmdReject").Visible = true;
            gvQuestCustom.MasterTableView.GetColumn("cmdReject").Visible = true;
        }

        gvQuest.Rebind();
        gvQuestCustom.Rebind();
        displayAmt();
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {

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
                a.DemandIntensity = Convert.ToInt32(ntbDemandIntensity.Text);
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

            if (a != null)
            {
                if (ntbM2.Value.HasValue)
                    a.DemandIntensity = Convert.ToInt32(ntbM2.Text);
                else
                    a.DemandIntensity = 0;
                dcTraining.SubmitChanges();
            }

        }
        //bindGvQuest();
        //bindGvQuestCustom();
        Show("已存檔");
        //RadAjaxPanel1.Alert("已存檔");
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
        // bool hasSend = false;   //紀碌需求是否送出
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
    protected void gvQuest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (tvDept.SelectedNode == null)
            return;

        QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
        var list = qdd3Repo.GetByYearDeptCode_Dlo(Convert.ToInt32(cbxYear.SelectedValue.ToString()), tvDept.SelectedValue);
        gvQuest.DataSource = (from c in list
                              select new
                              {
                                  c.Id,
                                  CourseName = c.trRequirementTemplateCourse.trCourse.sName,
                                  CourseCode = c.trRequirementTemplateCourse.trCourse.sCode,
                                  Amt = c.Amt,
                                  StudentNum = c.StudentNum,
                                  Minutes = c.Minutes,
                                  Month = c.Month,
                                  IsRequired = c.IsRequired,
                                  SuggestionPassItemName = c.trKnotTeaches == null ? "" : c.trKnotTeaches.KnotTeachesName,
                                  Budget = c.trRequirementTemplateCourse.Budget,
                                  IsRejection = c.IsRejection,
                                  Rejecter = c.BASE == null ? "" : c.BASE.NAME_C,
                                  MethodName = c.trTrainingMethod == null ? "" : c.trTrainingMethod.sName,
                                  RequestReason = c.RequestReason
                              }).ToList();
    }

    protected void gvQuestCustom_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (tvDept.SelectedNode == null)
            return;

        QuestDeptCustom3_Repo qdc3Repo = new QuestDeptCustom3_Repo();
        var list = qdc3Repo.GetByYearDeptCode_Dlo(Convert.ToInt32(cbxYear.SelectedValue.ToString()), tvDept.SelectedValue);
        gvQuestCustom.DataSource = (from c in list
                                    select new
                                    {
                                        c.Id,
                                        CourseName = c.CourseName,
                                        Amt = c.Amt,
                                        StudentNum = c.StudentNum,
                                        Minutes = c.Minutes,
                                        Month = c.Month,
                                        SuggestionPassItemName = c.trKnotTeaches == null ? "" : c.trKnotTeaches.KnotTeachesName,
                                        IsRejection = c.IsRejection,
                                        Rejecter = c.BASE == null ? "" : c.BASE.NAME_C,
                                        MethodName = c.trTrainingMethod == null ? "" : c.trTrainingMethod.sName,
                                        RequestReason = c.RequestReason
                                    }).ToList();
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

            QuestDeptCustom3_Repo qdc3Repo = new QuestDeptCustom3_Repo();
            var qdc3Obj = qdc3Repo.GetByPk(id);
            qdc3Repo.Delete(qdc3Obj);
            qdc3Repo.Save();
            gvQuestCustom.Rebind();
            displayAmt();
        }
    }
    protected void gvQuest_SelectedIndexChanged(object sender, EventArgs e)
    {
        winQuest.VisibleOnPageLoad = true;
        loadWinQuest(Convert.ToInt32(gvQuest.SelectedValue));
    }

    private void cleanWinQuest()
    {
        ntbAmt.Value = null;
        ntbMins.Value = null;
        ntbStudentNum.Value = null;
        cbMonth.ClearCheckedItems();
        cbTrainingMethod.ClearCheckedItems();
    }

    private void loadWinQuest(int id)
    {
        cleanWinQuest();

        QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
        QuestDeptDetail3 qdd3Obj = qdd3Repo.GetByPk(id);

        cbIsRequired.Checked = qdd3Obj.IsRequired;

        if (qdd3Obj.Amt.HasValue)
            ntbAmt.Value = qdd3Obj.Amt.Value;

        if (qdd3Obj.Minutes.HasValue)
            ntbMins.Value = qdd3Obj.Minutes;

        if (qdd3Obj.Month.HasValue)
        {
            cbMonth.ClearCheckedItems();
            RadComboBoxItem item = (from c in cbMonth.Items where c.Value.Equals(qdd3Obj.Month.Value.ToString()) select c).FirstOrDefault();
            if (item != null)
                item.Selected = true;
        }

        if (qdd3Obj.StudentNum.HasValue)
            ntbStudentNum.Value = qdd3Obj.StudentNum.Value;


        if (qdd3Obj.TrainingMethodCode != null)
        {
            cbTrainingMethod.ClearCheckedItems();
            RadComboBoxItem item = (from c in cbTrainingMethod.Items
                                    where c.Value.Equals(qdd3Obj.TrainingMethodCode)
                                    select c).FirstOrDefault();
            if (item != null)
                item.Selected = true;
        }

        if (qdd3Obj.SuggestionPassItem != null)
        {
            cbxSuggestionPassItem.ClearCheckedItems();
            RadComboBoxItem item = (from c in cbxSuggestionPassItem.Items
                                    where c.Value.Equals(qdd3Obj.SuggestionPassItem)
                                    select c).FirstOrDefault();
            if (item != null)
                item.Selected = true;
        }
    }


    protected void btnQuestSave_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(gvQuest.SelectedValue);
        QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
        QuestDeptDetail3 qdd3Obj = qdd3Repo.GetByPk(id);
        //qdd3Obj.IsRequired = cbIsRequired.Checked;
        qdd3Obj.IsRequired = true;

        if (ntbAmt.Value.HasValue)
            qdd3Obj.Amt = Convert.ToInt32(ntbAmt.Value);

        if (ntbMins.Value.HasValue)
            qdd3Obj.Minutes = Convert.ToInt32(ntbMins.Value);

        qdd3Obj.Month = Convert.ToInt32(cbMonth.SelectedValue);

        if (ntbStudentNum.Value.HasValue)
            qdd3Obj.StudentNum = Convert.ToInt32(ntbStudentNum.Value);

        qdd3Obj.TrainingMethodCode = cbTrainingMethod.SelectedValue;

        qdd3Obj.SuggestionPassItem = cbxSuggestionPassItem.SelectedValue;
        qdd3Obj.RequestReason = tbRequestReason.Text;

        qdd3Repo.Update(qdd3Obj);
        qdd3Repo.Save();
        gvQuest.Rebind();
        displayAmt();
        winQuest.VisibleOnPageLoad = false;
    }
    protected void btnCusSave_Click(object sender, EventArgs e)
    {
        if (IsRefresh)
        {
            gvQuest.Rebind();
            gvQuestCustom.Rebind();
            return;
        }

        if (tbCusCourseName.Text.Trim().Length == 0)
        {
            Show("需輸入需求課程名稱!!");
            return;
        }

        if (tvDept.SelectedNode == null)
        {
            Show("請先選擇部門!!");
            return;
        }

        QuestDeptCustom3_Repo qdc3Repo = new QuestDeptCustom3_Repo();
        QuestDeptCustom3 qdc3Obj = new QuestDeptCustom3();

        qdc3Obj.IsRequired = true;
        qdc3Obj.CourseName = tbCusCourseName.Text;
        qdc3Obj.DeptCode = tvDept.SelectedValue;
        qdc3Obj.Year = Convert.ToInt32(cbxYear.SelectedValue);


        if (ntbCusAmt.Value.HasValue)
            qdc3Obj.Amt = Convert.ToInt32(ntbCusAmt.Value);

        if (ntbCusMins.Value.HasValue)
            qdc3Obj.Minutes = Convert.ToInt32(ntbCusMins.Value);

        qdc3Obj.Month = Convert.ToInt32(cbCusMonth.SelectedValue);

        if (ntbCusStudentNum.Value.HasValue)
            qdc3Obj.StudentNum = Convert.ToInt32(ntbCusStudentNum.Value);

        qdc3Obj.TrainingMethodCode = cbCusTrainingMethod.SelectedValue;
        qdc3Obj.SuggestionPassItem = cbxCusSuggestionPassItem.SelectedValue;

        qdc3Obj.RequestReason = tbCusRequestReason.Text;

        qdc3Repo.Add(qdc3Obj);
        qdc3Repo.Save();

        gvQuestCustom.Rebind();
        displayAmt();
        winQuest.VisibleOnPageLoad = false;
    }
    protected void rbtnAddCourse_Click(object sender, EventArgs e)
    {
        winCus.VisibleOnPageLoad = true;
    }

    private void displayAmt()
    {
        if (tvDept.SelectedNode == null)
            return;

        int year = Convert.ToInt32(cbxYear.SelectedValue);
        string deptCode = tvDept.SelectedValue;

        QuestDept_Repo qdRepo = new QuestDept_Repo();
        qdRepo.CalcAmtByYearDept(year, deptCode);

        QuestDept qdObj = qdRepo.GetByYearDept(year, deptCode);
        if (qdObj != null)
        {
            if (qdObj.Amt.HasValue)
                lbAmt.Text = qdObj.Amt.Value.ToString();
        }
    }

    protected void gvQuest_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        if (e.CommandName.Equals("cmdUnSelect"))
        {
            int id = Convert.ToInt32(item["Id"].Text);
            QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
            QuestDeptDetail3 qdd3Obj = qdd3Repo.GetByPk(id);
            qdd3Obj.IsRequired = false;
            qdd3Obj.Amt = 0;
            qdd3Obj.Minutes = 0;
            qdd3Obj.StudentNum = 0;
            qdd3Obj.Month = null;
            qdd3Obj.TrainingMethodCode = null;
            qdd3Obj.SuggestionPassItem = null;
            qdd3Obj.RequestReason = "";
            qdd3Repo.Update(qdd3Obj);
            qdd3Repo.Save();
            gvQuest.Rebind();
            displayAmt();
        }
        else if (e.CommandName.Equals("cmdReject"))
        {
            int id = Convert.ToInt32(item["Id"].Text);
            QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
            QuestDeptDetail3 qdd3Obj = qdd3Repo.GetByPk(id);
            qdd3Obj.IsRejection = true;
            qdd3Obj.Rejecter = Juser.Nobr;
            qdd3Repo.Update(qdd3Obj);
            qdd3Repo.Save();
            gvQuest.Rebind();
            displayAmt();
        }

    }
    protected void btnShowSummury_Click(object sender, EventArgs e)
    {
        if (tvDept.SelectedNode == null)
        {
            Show("請選擇部門");
            return;
        }

        string urlSummury = @"~/eTraining/Reports/Plan/DeptPlanFill3Summury.aspx?Year=" + cbxYear.SelectedValue + @"&Dept="
            + tvDept.SelectedValue + @"&IncludeChild=" + cbIncludeChild.Checked;
        winOuter.NavigateUrl = urlSummury;
        winOuter.VisibleOnPageLoad = true;
    }

    protected void btnShowDetail_Click(object sender, EventArgs e)
    {
        if (tvDept.SelectedNode == null)
        {
            Show("請選擇部門");
            return;
        }

        string url = @"~/eTraining/Reports/Plan/DeptPlanFill3Detail.aspx?Year=" + cbxYear.SelectedValue + @"&Dept="
            + tvDept.SelectedValue + @"&IncludeChild=" + cbIncludeChild.Checked;
        winOuter.NavigateUrl = url;
        winOuter.VisibleOnPageLoad = true;
    }
}