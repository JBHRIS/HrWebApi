using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Collections.Generic;
using Repo;

public partial class eTraining_Admin_PlanFillS : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();     

    private void setPageEnable(bool value)
    {
        if (value == true)
        {
            btnCheck.Enabled = true;
            btnSave.Enabled = true;
            rbtnAddCourse.Enabled = true;
            gvCustom.Columns[2].Visible = true;
        }
        else
        {
            btnCheck.Enabled = false;
            btnSave.Enabled = false;
            rbtnAddCourse.Enabled = false;            
            gvCustom.Columns[2].Visible = false;
        }

    }

    private void bindGv()
    {
        sdsTrainingQuest.SelectParameters.Clear();
        sdsTrainingQuest.SelectParameters.Add("sNobr", Page.User.Identity.Name);
        sdsTrainingQuest.SelectParameters.Add("Year", cbxYear.SelectedValue);
        gv.Rebind();
    }

    private void bindGvCustom()
    {
        sdsCustom.SelectParameters.Clear();
        sdsCustom.SelectParameters.Add("sNobr", Page.User.Identity.Name);
        sdsCustom.SelectParameters.Add("Year", cbxYear.SelectedValue);
        gvCustom.Rebind();
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        checkClosed();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);

            //設定已開放填寫需求的年度為預設年度
            trRequirementTemplateRecord_Repo rtrRepo = new trRequirementTemplateRecord_Repo();
            List<trRequirementTemplateRecord> list= rtrRepo.GetByIsClosed(false);
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

            bindGv();
            bindGvCustom();                             
        }
    }

    //確認使用者是否有輸入正確的需求數量
    private bool isFillNummCorrect(out string msg,string year)
    {

        //判斷各類別是否有按照正確需填寫數量填寫
        msg = "";
        int iyear = Convert.ToInt32(year);
        int inputQty =0 ; //輸入的數量


        var objTemplateRecord = (from c in dcTraining.trRequirementTemplateRecord
                                         where c.iYear == iyear select c).FirstOrDefault();

        if(objTemplateRecord ==null)
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

        foreach (GridDataItem item in gv.Items)
        {
            RadNumericTextBox ntbP = item["COL_P"].FindControl("ntbP") as RadNumericTextBox;

            int int_value = Convert.ToInt32(ntbP.Text);

            //0當作沒輸入
            if (int_value == 0)
                continue;
            else
            {
                inputQty++;
                int data = (from c in templateCats
                            where c.sCode == item["catCode"].Text
                            select c.iFillMaxNum).FirstOrDefault();

                if (data==0)
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string msg;
        if (!isFillNummCorrect(out msg, cbxYear.SelectedValue))
        {
            AlertMsg(msg);
            return;
        }

        foreach (GridDataItem item in gv.Items)
        {
            RadNumericTextBox ntbP = item["COL_P"].FindControl("ntbP") as RadNumericTextBox;            

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuest
                    where c.iAutoKey == Convert.ToInt32(key)
                    select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityP = Convert.ToInt32(ntbP.Text);
                dcTraining.SubmitChanges();
            }

        }

        foreach (GridDataItem item in gvCustom.Items)
        {
            RadNumericTextBox ntbCP = item["iDemandIntensityP"].FindControl("ntbCP") as RadNumericTextBox;

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuestCustom
                     where c.iAutoKey == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityP = Convert.ToInt32(ntbCP.Text);                
                dcTraining.SubmitChanges();
            }
        }
        
        gv.Rebind();
        gvCustom.Rebind();
        AlertMsg("已存檔");
        //RadAjaxPanel1.Alert("已存檔");
    }		 	

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        string msg;
        if (!isFillNummCorrect(out msg, cbxYear.SelectedValue))
        {
            AlertMsg(msg);
            //RadAjaxPanel1.Alert(msg);
            return;
        }
        
        foreach (GridDataItem item in gv.Items)
        {
            RadNumericTextBox ntbP = item["COL_P"].FindControl("ntbP") as RadNumericTextBox;
            //RadNumericTextBox ntbM = item.Cells[COL_P].FindControl("ntbM") as RadNumericTextBox;

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuest
                     where c.iAutoKey == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityP = Convert.ToInt32(ntbP.Text);
                a.iDemandIntensityPdate = DateTime.Now;
                //lblMsg.Text = "已送出!!";
                dcTraining.SubmitChanges();
            }
        }

        foreach (GridDataItem item in gvCustom.Items)
        {
            RadNumericTextBox ntbCP = item["iDemandIntensityP"].FindControl("ntbCP") as RadNumericTextBox;            

            string key = item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();

            var a = (from c in dcTraining.trTrainingQuestCustom
                     where c.iAutoKey == Convert.ToInt32(key)
                     select c).FirstOrDefault();

            if (a != null)
            {
                a.iDemandIntensityP = Convert.ToInt32(ntbCP.Text);
                a.iDemandIntensityPdate = DateTime.Now;                
                dcTraining.SubmitChanges();
            }
        }

        bindGv();
        bindGvCustom();
        AlertMsg("已送出");
        //RadAjaxPanel1.Alert("已送出");
    }
    protected void cbxYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        bindGv();
        bindGvCustom();
    }
    protected void cbxYear_Load(object sender, EventArgs e)
    {

    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }

    private void checkClosed()
    {
        bool hasSend = false;   //是否送出需求
        bool isPlanQuestionClosed = false;   //需求填寫是否關閉

        PlanHelper planHelper = new PlanHelper();
        isPlanQuestionClosed = planHelper.isPlanQuestionClosed(Convert.ToInt32(cbxYear.SelectedValue));

        //如果年度計畫填寫已關閉，就不進來
        if (isPlanQuestionClosed==false)
        {
            var pdate = (from c in dcTraining.trTrainingQuest
                         where c.iDemandIntensityPdate != null &&
                         c.sNobr == User.Identity.Name &&
                         c.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                         select c.iDemandIntensityPdate).FirstOrDefault();
            //是空的，代表已填寫完
            if (pdate != null)
            {
                hasSend = true;
            }
        }

        if (isPlanQuestionClosed)
        {
            lblMsg.Text = "需求填寫已關閉";
            setPageEnable(false);
        }
        else if (hasSend)
        {
            lblMsg.Text = "需求填寫已送出";
            setPageEnable(false);
        }
        else
        {
            lblMsg.Text = "";
            setPageEnable(true);
        }        
    }
    protected void rbtnAddCourse_Click(object sender, EventArgs e)
    {
        if(IsRefresh)
        {
            gvCustom.Rebind();
            return;
        }

        if (tbCourseName.Text.Trim().Length > 0)
        {
            trTrainingQuestCustom obj = new trTrainingQuestCustom();
            obj.iDemandIntensityP = 0;
            obj.iDemandIntensityM = 0;
            obj.iYear = Convert.ToInt32(cbxYear.SelectedValue);
            obj.sCourseName = tbCourseName.Text;
            obj.sNobr = User.Identity.Name;


            var data = (from c in dcTraining.trTrainingQuest
                        where c.sNobr == User.Identity.Name
                            && c.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                        select c).FirstOrDefault();

            if (data != null)
            {
                obj.sDeptCode = data.sDeptCode;
                obj.sJobCode = data.sJobCode;
                obj.sJoblCode = data.sJoblCode;
                obj.sJobsCode = data.sJoblCode;
                obj.sManage = data.sManage;                
            }

            dcTraining.trTrainingQuestCustom.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();

            bindGvCustom();

            tbCourseName.Text = "";

        }
    }

}