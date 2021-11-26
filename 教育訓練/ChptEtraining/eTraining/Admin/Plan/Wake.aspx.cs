using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Admin_Plan_Wake : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private BASE_Repo baseRepo = new BASE_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbYear);
        }
        this.Title = "提醒";        
    }
    

    public List<string> getNobrList(RadGrid gv)
    {
        List<string> list = new List<string>();

        if (gv.ID.Equals("gvP"))
        {
            foreach (GridDataItem item in gv.Items)
            {
                string nobr = item["sNobr"].Text.ToString();
                list.Add(nobr);
            }
        }
        else
        {
            foreach (GridDataItem item in gv.Items)
            {
                string nobr = item["sManage"].Text.ToString();
                list.Add(nobr);
            }
        }

        //去除重複工號
        return list.Distinct().ToList();
    }

   protected void btnMailPreView_Click(object sender , EventArgs e)
    {
        //抓取公版的郵件設定
        //var mailNotify = (from c in dcTraining.mtCode
        //                  where c.sCategory == "MailNotify" && c.sCode == "QuestionWake"
        //                  select c).FirstOrDefault();

        //if ( mailNotify == null || mailNotify.s1 == "0" )
        //{
        //    RadAjaxPanel1.Alert("還未設定郵件樣板");
        //    //RadAjaxPanel1.Alert("還未設定郵件樣板");
        //    return;
        //}

        BASE_Repo baseRepo = new BASE_Repo();

        MailNotify mailNotify = new MailNotify();
        mailNotify.SetMailTemplate(Convert.ToInt32(cbxMail.SelectedValue));

        List<string> nobrList = new List<string>();
        //員工未填寫
        if (rrlCate.SelectedValue.Equals("0"))
        {
            gvP.AllowPaging = false;
            gvP.Rebind();
            nobrList = getNobrList(gvP);

            gvP.AllowPaging = true;
            gvP.Rebind();
        }
        else
        {
            gvM.AllowPaging = false;
            gvM.Rebind();
            nobrList = getNobrList(gvM);

            gvM.AllowPaging = true;
            gvM.Rebind();
        }

        foreach (string nobr in nobrList)
        {
            mailNotify.Email.Clear();
            mailNotify.SetNobr(nobr);
            BASE baseObj= baseRepo.GetByNobr(nobr);

            if (baseObj.EMAIL == null || !MailVariable.IsEmail(baseObj.EMAIL))
            {
                //Email有問題，提醒管理者
                trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                trErrorNotify errorNotifyAdmin = new trErrorNotify();
                errorNotifyAdmin.ErrorMsg = "員工:" + nobr + "尚未設定Email";
                errorNotifyAdmin.NotifyDate = DateTime.Now;
                errorNotifyAdmin.sKeyMan = User.Identity.Name;
                errorNotifyAdmin.TargetNobr = null;
                errorNotifyAdmin.TargetRole = 1;
                errorNotifyRepo.Add(errorNotifyAdmin);
                errorNotifyRepo.Save();
                logger.Warn(nobr + "have no email");
                continue;
            }

            //通知訊息提醒使用者
            trErrorNotify_Repo errorNotifyEmpRepo = new trErrorNotify_Repo();
            trErrorNotify errorNotify = new trErrorNotify();
            errorNotify.ErrorMsg = "提醒您有新年度的課程調查需求需填寫";
            errorNotify.NotifyDate = DateTime.Now;
            errorNotify.sKeyMan = User.Identity.Name;
            errorNotify.TargetNobr = nobr;
            errorNotify.TargetRole = null;
            errorNotifyEmpRepo.Add(errorNotify);
            errorNotifyEmpRepo.Save();

            mailNotify.Email.Add(baseObj.EMAIL);


            RadButton btn = sender as RadButton;
            if ( btn.ID.Equals("btnMailPreView") )
            {
                string subject , content;
                mailNotify.Preview(out subject , out content);
                lblMailSubject.Text = subject;
                lblMailBody.Text = content;
                pnPreView.Visible = true;
                break;
            }
            else
            {
                mailNotify.SendMail();
            }
            
        }

        //Preview還是要bind一下GV，以免不好看
        //員工未填寫
        if ( rrlCate.SelectedValue.Equals("0") )
        {
            gvP.AllowPaging = true;
            gvP.Rebind();
        }
        else
        {
            gvM.AllowPaging = true;
            gvM.Rebind();
        }
    }
    protected void cbYear_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
    {
       


    }
    protected void cbYear_DataBound(object sender, EventArgs e)
    {
        //checkYearQuestClosed();
    }

    //private void checkYearQuestClosed()
    //{
    //    int year = 0;
    //    if (int.TryParse(cbYear.SelectedValue.ToString(), out year))
    //    {
    //        PlanHelper planHelper = new PlanHelper();
    //        if (planHelper.IsYearQuestClosed(year))
    //            btnSendMail.Enabled = false;
    //        else
    //            btnSendMail.Enabled = true;
    //    }
    //}
    protected void cbYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //checkYearQuestClosed();
    }
    protected void btnEmpExportExcel_Click(object sender , EventArgs e)
    {
        gvP.ExportSettings.ExportOnlyData = true;
        gvP.ExportSettings.HideStructureColumns = true;
        gvP.ExportSettings.IgnorePaging = true;
        gvP.ExportSettings.OpenInNewWindow = false;
        gvP.ExportSettings.FileName = cbYear.SelectedValue.ToString() + "需求未填寫名單";
        gvP.MasterTableView.ExportToExcel();  
    }
    protected void btnMangExportExcel_Click(object sender , EventArgs e)
    {
        gvM.ExportSettings.ExportOnlyData = true;
        gvM.ExportSettings.HideStructureColumns = true;
        gvM.ExportSettings.IgnorePaging = true;
        gvM.ExportSettings.OpenInNewWindow = false;
        gvM.ExportSettings.FileName = cbYear.SelectedValue.ToString() + "主管未填寫名單";
        gvM.MasterTableView.ExportToExcel();  
    }
    protected void gvM_SelectedIndexChanged(object sender , EventArgs e)
    {

    }
    protected void gvM_ItemCommand(object sender , GridCommandEventArgs e)
    {
        Panel1.Visible = true;
        if ( e.CommandName.Equals("Select") )
        {
            Panel1.Visible = true;
        }
    }
    protected void gvNobr_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        gvNobr.DataSource = (from c in baseRepo.GetHiredEmpBySeachKey_DLO(txtName.Text)
                             select new
                             {
                                 Nobr = c.NOBR
                                 ,
                                 DeptName = c.BASETTS[0].DEPT1.D_NAME
                                 ,
                                 NAME_C = c.NOBR + c.NAME_C
                                 ,
                                 JobName = c.BASETTS[0].JOB1.JOB_NAME
                             }
                     ).ToList();
    }
    protected void btnReplaceManager_Click(object sender , EventArgs e)
    {
        if ( gvM.SelectedItems.Count <= 0 || gvNobr .SelectedItems.Count <=0)
        {
            RadAjaxPanel1.Alert("尚未選擇人員");
        }
        else
        {
            GridDataItem item= gvM.SelectedItems[0] as GridDataItem;
            string manager = item["sManage"].Text;
            string emp = item["empNobr"].Text;
            int year = Convert.ToInt32(cbYear.SelectedValue);

            string switchManager= gvNobr.SelectedValue.ToString();

            trTrainingQuest_Repo tqRepo = new trTrainingQuest_Repo();
            List<trTrainingQuest> list= tqRepo.GetByYearNobrManager(year , emp , manager);

            foreach ( trTrainingQuest i in list )
            {
                i.sManage = switchManager;                
            }

            tqRepo.UpdateList(list);
            tqRepo.Save();
            gvM.Rebind();

            //item["sManage"].Text;
        }

    }
    protected void btnCancel_Click(object sender , EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btnSearchNobr_Click(object sender , EventArgs e)
    {
        gvNobr.Rebind();
        txtName.Focus();
    }
}