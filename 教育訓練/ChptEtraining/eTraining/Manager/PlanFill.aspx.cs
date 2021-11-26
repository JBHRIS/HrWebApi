using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using Repo;
public partial class eTraining_Manager_PlanFill : System.Web.UI.Page
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

            sdsName.SelectParameters.Clear();
            sdsName.SelectParameters.Add("Manage", Page.User.Identity.Name);
            tvDept.DataBind();

        }
    }

    private void setPageEnable(bool value)
    {
            gvQuest.Enabled = value; 
            btnCheck.Enabled = value;
            btnSave.Enabled = value;
    }


    protected void tvDept_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        bindGvQuest();
        bindGvQuestCustom();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string msg;
        if (!isFillNummCorrect(out msg, cbxYear.SelectedValue))
        {
            RadAjaxPanel1.Alert(msg);
            return;
        }

        //將gvQuest的主管需求存入trTrainingQuest
        foreach (GridDataItem itm in gvQuest.Items)
        {
            RadNumericTextBox ntbM = itm["COL_M"].FindControl("ntbM") as RadNumericTextBox;

            string key = itm.OwnerTableView.DataKeyValues[itm.ItemIndex]["iAutoKey"].ToString();
            var a = (from c in dcTraining.trTrainingQuest
                     where c.iAutoKey == Convert.ToInt32(key)
                     select c).FirstOrDefault();
            if (a != null)
            {
                a.iDemandIntensityM = Convert.ToInt32(ntbM.Text);
                dcTraining.SubmitChanges();
            }
        }

        //將gvQuestCustom的主管需求存入trTrainingQuestCustom
        foreach (GridDataItem item in gvQuestCustom.Items)
        {
            RadNumericTextBox ntbM2 = item["COL_M"].FindControl("ntbM2") as RadNumericTextBox;

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuestCustom
                     where c.iAutoKey == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityM = Convert.ToInt32(ntbM2.Text);
                dcTraining.SubmitChanges();
            }

        }
        bindGvQuest();
        bindGvQuestCustom();
        RadAjaxPanel1.Alert("已存檔");
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string msg;
        if (!isFillNummCorrect(out msg, cbxYear.SelectedValue))
        {
            RadAjaxPanel1.Alert(msg);
            return;
        }

        foreach (GridDataItem item in gvQuest.Items)
        {
            RadNumericTextBox ntbM = item["COL_M"].FindControl("ntbM") as RadNumericTextBox;


            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuest
                     where c.iAutoKey == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityM = Convert.ToInt32(ntbM.Text);
                a.iDemandIntensityMdate = DateTime.Now;

                dcTraining.SubmitChanges();
            }

        }
        foreach (GridDataItem item in gvQuestCustom.Items)
        {
            RadNumericTextBox ntbM2 = item["COL_M"].FindControl("ntbM2") as RadNumericTextBox;

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuestCustom
                     where c.iAutoKey == Convert.ToInt64(key)
                     select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityM = Convert.ToInt32(ntbM2.Text);
                a.iDemandIntensityMdate = DateTime.Now;
                dcTraining.SubmitChanges();
            }
        }

        bindGvQuest();
        bindGvQuestCustom();
        RadAjaxPanel1.Alert("已送出");
    }
    protected void cbxYear_Load(object sender, EventArgs e)
    {
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        checkClosed();
    }

    //確認使用者是否有輸入正確的需求數量 for 主管
    private bool isFillNummCorrect(out string msg, string year)
    {
        msg = "";
        int iyear = Convert.ToInt32(year);
        int inputQty = 0; //輸入的數量

        var objTemplateRecord = (from c in dcTraining.trRequirementTemplateRecord
                                 where c.iYear == iyear
                                 select c).FirstOrDefault();

        if (objTemplateRecord == null)
        {
            throw new ApplicationException("年度調查需求課程設定資料不完整，請確認");

        }

        var templateCats = (from c in dcTraining.trRequirementTemplateDetail
                            join d in dcTraining.trRequirementTemplateCat
                            on c.Rtc_sCode equals d.sCode
                            where c.Rt_sCode == objTemplateRecord.Rt_sCode
                            select d).ToList();

        Dictionary<String, int> dic = new Dictionary<string, int>();

        foreach (var i in templateCats)
            dic.Add(i.sCode, i.iFillMaxNum);

        foreach (GridDataItem item in gvQuest.Items)
        {
            RadNumericTextBox ntbM = item["COL_M"].FindControl("ntbM") as RadNumericTextBox;

            int int_value = Convert.ToInt32(ntbM.Text);

            //0當作沒輸入
            if (int_value == 0)
                continue;
            else
            {
                inputQty++;
                int data = (from c in templateCats
                            where c.sCode == item["catCode"].Text
                            select c.iFillMaxNum).FirstOrDefault();

                if (data == 0)
                    continue;
                else
                    dic[item["catCode"].Text] = dic[item["catCode"].Text] - 1;
            }
        }

        foreach (KeyValuePair<string, int> pair in dic)
        {
            if (pair.Value < 0)
            {
                var cat = (from c in dcTraining.trRequirementTemplateCat
                           where c.sCode == pair.Key
                           select c).FirstOrDefault();

                msg = "需求類別只能輸入 " + cat.iFillMaxNum.ToString() + " 項、您輸入了 " + (System.Math.Abs(pair.Value) + cat.iFillMaxNum).ToString() + " 項";
                return false;
            }
            else if (pair.Value > 0)
            {
                var cat = (from c in dcTraining.trRequirementTemplateCat
                           where c.sCode == pair.Key
                           select c).FirstOrDefault();

                msg = "需求類別需輸入 " + cat.iFillMaxNum.ToString() + " 項、您輸入了 " + (cat.iFillMaxNum - System.Math.Abs(pair.Value)).ToString() + " 項";
                return false;
            }
        }

        //檢查整張需求單，是否有按照整張須填寫數量填寫
        if (inputQty == 0)
        {
            msg = "調查至少需輸入 1 項";
            return false;
        }

        return true;
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
            //抓取主管填寫是否已送出
            var mdate = (from c in dcTraining.trTrainingQuest
                         where c.sNobr == tvDept.SelectedValue
                         && c.sManage == Page.User.Identity.Name
                         && c.iDemandIntensityMdate != null
                         && c.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                         select c.iDemandIntensityMdate).FirstOrDefault();

            //已存入填寫日期，代表已填寫完
            if (mdate != null)
            {
                hasSend = true;
            }
        }

        //查詢點選的員工是否已送出需求
        var pdate = (from c in dcTraining.trTrainingQuest
                     where c.iDemandIntensityPdate != null &&
                     c.sNobr == tvDept.SelectedValue &&
                     c.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                     select c.iDemandIntensityPdate).FirstOrDefault();

        //需求填寫關閉
        if (isPlanQuestionClosed)
        {
            lblMsg.Text = "需求填寫已關閉";
            setPageEnable(false);
        }
        //需求填寫未關閉且主管需求填寫已送出(hasSend=true)
        else if (hasSend)
        {
            lblMsg.Text = "需求填寫已送出";
            setPageEnable(false);
        }
        //需求填寫未關閉且員工需求填寫未送出
        else if (pdate == null)
        {
            lblMsg.Text = "員工尚未填寫";
            setPageEnable(false);
        }
        //需求填寫未關閉且員工需求填寫已送出
        else
        {
            lblMsg.Text = "";
            //將狀態設為可存檔可送出
            setPageEnable(true);
        }
    }

    private void bindGvQuest()
    {
        sdsQuest.SelectParameters.Clear();
        sdsQuest.SelectParameters.Add("Nobr", tvDept.SelectedValue);
        sdsQuest.SelectParameters.Add("Year", cbxYear.SelectedValue);
        gvQuest.Rebind();
    }

    private void bindGvQuestCustom()
    {
        sdsCustom.SelectParameters.Clear();
        sdsCustom.SelectParameters.Add("Nobr", tvDept.SelectedValue);
        sdsCustom.SelectParameters.Add("Year", cbxYear.SelectedValue);
        gvQuestCustom.Rebind();
    }
    protected void gvQuest_ItemDataBound(object sender, GridItemEventArgs e)
    {
    }
    protected void cbxYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindGvQuest();
        bindGvQuestCustom();
    }
    protected void sdsQuest_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
    }
    protected void gvOtherQuest_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
}