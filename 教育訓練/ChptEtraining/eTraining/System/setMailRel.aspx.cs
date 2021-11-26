using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_System_setMailRel : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    mtCode_Repo mtCodeRepo = new mtCode_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cbxQuestionNotify.DataBind();
            cbxQuestionWakeNotify.DataBind();
            cbxClassReportRejection.DataBind();
            setCbxSelected();
            changeMode("v");
        }
    }

    private void setCbxSelected()
    {
        var dataList = (from c in dcTraining.mtCode
                    where c.sCategory == "MailNotify"
                    select c).ToList();

        //需求調查
        int intQuestionKey = 0;
        var data = (from c in dataList
                    where c.sCode == "Question"
                    select c).FirstOrDefault();

        if (data != null)
        {
            intQuestionKey = Convert.ToInt32(data.s1);
        }
        else
        {
            mtCode obj = new mtCode();
            obj.sCode = "Question";
            obj.sCategory = "MailNotify";
            obj.s1 = "0";
            obj.sName = "需求樣板通知";
            dcTraining.mtCode.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
        }

        RadComboBoxItem questionNotifyItem = cbxQuestionNotify.Items.FindItemByValue(intQuestionKey.ToString());
        if (questionNotifyItem != null)
            questionNotifyItem.Selected = true;

        //需求調查提醒
        int intQuestionWakeKey = 0;

        var data1 = (from c in dataList
                     where c.sCode == "QuestionWake"
                    select c).FirstOrDefault();

        if (data1 != null)
        {
            intQuestionWakeKey = Convert.ToInt32(data1.s1);
        }
        else
        {
            mtCode obj = new mtCode();
            obj.sCode = "QuetionWake";
            obj.sCategory = "MailNotify";
            obj.s1 = "0";
            obj.sName = "需求樣板稽催通知";
            dcTraining.mtCode.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
        }

        RadComboBoxItem questionWakeItem = cbxQuestionWakeNotify.Items.FindItemByValue(intQuestionWakeKey.ToString());
        if (questionWakeItem != null)
            questionWakeItem.Selected = true;


        //講師退心得的學員通知範本
        int classReportRejectionSelectedKey = 0;
        var classReportRejectionObj = (from c in dataList
                     where c.sCode == "ClassReportRejection"
                     select c).FirstOrDefault();

        if (classReportRejectionObj != null)
        {
            classReportRejectionSelectedKey = Convert.ToInt32(classReportRejectionObj.s1);
        }
        else
        {
            mtCode obj = new mtCode();
            obj.sCode = "ClassReportRejection";
            obj.sCategory = "MailNotify";
            obj.s1 = "0";
            obj.sName = "學員心得被講師退件郵件通知範本";
            dcTraining.mtCode.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
        }

        RadComboBoxItem classReportRejectionItem = cbxClassReportRejection.Items.FindItemByValue(classReportRejectionSelectedKey.ToString());
        if (classReportRejectionItem != null)
            classReportRejectionItem.Selected = true;

    }

    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
            lblAutoKey.Text = key;
            changeMode("e");
        }
    }

    private void changeMode(string mode)
    {
        lblMode.Text = mode;         

        if (mode == "v")
        {            
            lblAutoKey.Text = "";                      
            setPanelDefault();
        }
        else if (mode == "i")
        {         
            tbName.Text = "";
            tbSubject.Text = "";
            edt.Content = "";
            //pnView.Visible = false;
            //pnEdit.Visible = true;            
        }
        else if (mode == "e")
        {
            loadEditData();
            //pnView.Visible = false;
            //pnEdit.Visible = true;            
        }
    }

    private void setPanelDefault()
    {
        pnView.Visible = true;
        pnEdit.Visible = true;
    }

    private void loadEditData()
    {
        var data = (from c in dcTraining.trMailTemplate
                    where c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                    select c).FirstOrDefault();

        if (data != null)
        {
            tbName.Text = data.sName;
            tbSubject.Text = data.sMailSubject;
            edt.Content = data.sMailContent;
        }
    }
    protected void btnQuestionSave_Click(object sender, EventArgs e)
    {
        var a = (from c in dcTraining.mtCode
                 where c.sCategory == "MailNotify" && c.sCode == "Question"
                 select c).FirstOrDefault();

        if (a != null)
        {
            a.s1 = cbxQuestionNotify.SelectedValue;
            dcTraining.SubmitChanges();
            cbxBind();
            //cbxQuestionNotify.DataBind();
            //cbxQuestionWakeNotify.DataBind();
            setCbxSelected();
            AlertMsg("已存檔");
        }
    }
    protected void btnQuestionWakeSave_Click(object sender, EventArgs e)
    {
        var a = (from c in dcTraining.mtCode
                 where c.sCategory == "MailNotify" && c.sCode == "QuestionWake"
                 select c).FirstOrDefault();

        if (a != null)
        {
            a.s1 = cbxQuestionWakeNotify.SelectedValue;
            dcTraining.SubmitChanges();
            cbxBind();                        
            //cbxQuestionNotify.DataBind();
            //cbxQuestionWakeNotify.DataBind();
            setCbxSelected();
            AlertMsg("已存檔");
        }                        
    }

    private void cbxBind()
    {       
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = "未設定";
        item.Value = "0";        
        cbxQuestionNotify.Items.Clear();
        cbxQuestionNotify.Items.Add(item);
        cbxQuestionNotify.DataBind();
        
        RadComboBoxItem item1 = new RadComboBoxItem();
        item1.Text = "未設定";
        item1.Value = "0";
        cbxQuestionWakeNotify.Items.Clear();
        cbxQuestionWakeNotify.Items.Add(item1);
        cbxQuestionWakeNotify.DataBind();

 
    }
    protected void btnClassRpt_Click(object sender, EventArgs e)
    {
        var a = (from c in dcTraining.mtCode
                 where c.sCategory == "MailNotify" && c.sCode == "ClassRpt"
                 select c).FirstOrDefault();

        if (a != null)
        {
            setCbxSelected();
            AlertMsg("已存檔");
        }      
    }
    protected void btnClassReportRejection_Click(object sender, EventArgs e)
    {
        var mtCodeObj = mtCodeRepo.GetByCategroyCode("MailNotify", "ClassReportRejection");

        if (mtCodeObj != null)
        {
            mtCodeObj.s1 = cbxClassReportRejection.SelectedValue;
            mtCodeRepo.Update(mtCodeObj);
            mtCodeRepo.Save();
            setCbxSelected();
            AlertMsg("已存檔");
        }
    }
}