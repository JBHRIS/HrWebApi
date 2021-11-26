using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Reports_Do_ClassQuestionnaireLackList : JBWebPage
{
    bool isExport = false;
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    private trTrainingStudentM_Repo smRepo = new trTrainingStudentM_Repo();
    private BASETTS_Repo ttsRepo = new BASETTS_Repo();
    private trTrainingDetailM_Repo dmRepo = new trTrainingDetailM_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            rdpAdate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            rdpDdate.SelectedDate = DateTime.Now;
        }
    }


    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        gv.ExportSettings.ExportOnlyData = false;
        gv.ExportSettings.HideStructureColumns = false;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        isExport = true;
        string fileName = rdpAdate.SelectedDate.Value.ToShortDateString() + "~" + rdpDdate.SelectedDate.Value.ToShortDateString() + "心得缺繳";
        gv.ExportSettings.FileName = fileName;
        gv.MasterTableView.ExportToExcel();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gv.Rebind();
    }
    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
        {
            e.Item.Visible = false;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        int errCounter = 0;
        RadButton btn = sender as RadButton;
        string subject, content;
        MailNotify mailNotify = new MailNotify();
        DoHelper doHelper = new DoHelper();

        if (rbl.SelectedItem == null && rbl.Enabled == true)
        {
            AlertMsg("未選擇寄送項目");
            return;
        }

        if (btn.Text.Equals("預覽"))
            pnView.Visible = true;
        else
            pnView.Visible = false;

        /////////////////////////////寄送信件
        //已發送課程清單，給講師用的
        //List<int> haveSentClass = new List<int>();

        qBaseM_Repo qbmRepo = new qBaseM_Repo();

        foreach (GridDataItem item in gv.Items)
        {
            trTrainingDetailM dm = dmRepo.GetByKey_DLO(Convert.ToInt32(item["ClassId"].Text));
            qBaseM bm = qbmRepo.GetByAutoKey_DLO(Convert.ToInt32(item["AutoKey"].Text));
            if (dm != null)
                mailNotify.mailVariable.TDM = dm;

            //講師
            if (cbType.SelectedValue.Equals("T"))
            {
                mailNotify.Email.Clear();

                if (bm.trTeacher.sEmail == null || !MailVariable.IsEmail(bm.trTeacher.sEmail))
                {
                    trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                    trErrorNotify errorNotifyAdmin = new trErrorNotify();
                    errorNotifyAdmin.ErrorMsg = "講師:" + bm.trTeacher.sName + "未設定Email，未通知。";
                    errorNotifyAdmin.NotifyDate = DateTime.Now;
                    errorNotifyAdmin.sKeyMan = User.Identity.Name;
                    errorNotifyAdmin.TargetNobr = null;
                    errorNotifyAdmin.TargetRole = 1;
                    errorNotifyRepo.Add(errorNotifyAdmin);
                    errorNotifyRepo.Save();

                    continue;
                }

                mailNotify.SetTrainingDetailM(bm.iClassAutoKey.Value);
                mailNotify.Email.Add(bm.trTeacher.sEmail);
                mailNotify.SetMailTemplate(Convert.ToInt32(cbxMail.SelectedValue));

                if (btn.Text.Equals("預覽"))
                {
                    mailNotify.Preview(out subject, out content);
                    lblMailSubject.Text = subject;
                    lblMailBody.Text = content;
                    break;
                }
                else
                {
                    if (!mailNotify.SendMail())
                        errCounter++;
                }
            }
            else if (cbType.SelectedValue.Equals("M"))
            {
                AlertMsg("組訓員不提供郵件通知");
            }
            else //(rbl.SelectedValue.Equals("3") || rbl.SelectedValue.Equals("4")
            //|| rbl.SelectedValue.Equals("5") || rbl.SelectedValue.Equals("6"))
            {
                mailNotify.Email.Clear();

                trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
                trTrainingStudentM sm = tsmRepo.GetByNobrClassId_DLO(item["Nobr"].Text, Convert.ToInt32(item["ClassId"].Text));

                if (sm.BASE.EMAIL == null || !MailVariable.IsEmail(sm.BASE.EMAIL))
                {
                    trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                    trErrorNotify errorNotifyAdmin = new trErrorNotify();
                    errorNotifyAdmin.ErrorMsg = "工號:" + sm.BASE.NOBR + "(" + sm.BASE.NAME_C + ")" + "未設定Email，未通知";
                    errorNotifyAdmin.NotifyDate = DateTime.Now;
                    errorNotifyAdmin.sKeyMan = User.Identity.Name;
                    errorNotifyAdmin.TargetNobr = null;
                    errorNotifyAdmin.TargetRole = 1;
                    errorNotifyRepo.Add(errorNotifyAdmin);
                    errorNotifyRepo.Save();

                    continue;
                }
                mailNotify.SetTrainingDetailM(bm.iClassAutoKey.Value);
                mailNotify.SetNobr(sm.BASE.NOBR);
                mailNotify.Email.Add(sm.BASE.EMAIL);

                List<BASETTS> managers = new List<BASETTS>();

                if (rbl.SelectedValue.Equals("4"))
                    managers = ttsRepo.GetDeptManagerByNobrDeptLevel(sm.BASE.NOBR, 0);
                else if (rbl.SelectedValue.Equals("5"))
                    managers = ttsRepo.GetDeptManagerByNobrDeptLevel(sm.BASE.NOBR, 1);
                else if (rbl.SelectedValue.Equals("6"))
                    managers = ttsRepo.GetDeptManagerByNobrDeptLevel(sm.BASE.NOBR, 2);

                foreach (var m in managers)
                {
                    if (m.BASE.EMAIL == null || !MailVariable.IsEmail(m.BASE.EMAIL))
                    {
                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
                        errorNotifyAdmin.ErrorMsg = "工號:" + m.BASE.NOBR + "(" + m.BASE.NAME_C + ")" + "未設定Email，主管未通知。";
                        errorNotifyAdmin.NotifyDate = DateTime.Now;
                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
                        errorNotifyAdmin.TargetNobr = null;
                        errorNotifyAdmin.TargetRole = 1;
                        errorNotifyRepo.Add(errorNotifyAdmin);
                        errorNotifyRepo.Save();
                    }
                    else
                        mailNotify.Email.Add(m.BASE.EMAIL);
                }

                mailNotify.SetMailTemplate(Convert.ToInt32(cbxMail.SelectedValue));
                if (btn.Text.Equals("預覽"))
                {
                    mailNotify.Preview(out subject, out content);
                    lblMailSubject.Text = subject;
                    lblMailBody.Text = content;
                    break;
                }
                else
                {
                    if (!mailNotify.SendMail())
                        errCounter++;
                }
                //}
            }
        }

        if (!btn.Text.Equals("預覽"))
        {
            if (errCounter > 0)
                AlertMsg("寄送信件有" + errCounter.ToString() + "筆錯誤，請檢視郵件紀錄");
            else
                AlertMsg("已寄送");
        }
    }

    protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cbType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cbType.SelectedValue.Equals("T"))
            rbl.Enabled = false;
        else
            rbl.Enabled = true;

        if (cbType.SelectedValue.Equals("M"))
        {
            btnView.Enabled = false;
            btnSend.Enabled = false;
        }
        else
        {
            btnView.Enabled = true;
            btnSend.Enabled = true;
        }

        gv.Rebind();
    }
    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        qBaseM_Repo qBasemRepo = new qBaseM_Repo();
        gv.DataSource = qBasemRepo.GetByWriteDateNull_DLO(rdpAdate.SelectedDate.Value, rdpDdate.SelectedDate.Value, cbType.SelectedValue);
    }
    protected void cbType_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cbType.SelectedIndex = 0;
            cbType_SelectedIndexChanged(null, null);
        }
    }
}