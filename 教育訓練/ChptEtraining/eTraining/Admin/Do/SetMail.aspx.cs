using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Admin_Do_SetMail : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trTrainingStudentM_Repo smRepo = new trTrainingStudentM_Repo();
    private BASETTS_Repo ttsRepo = new BASETTS_Repo();
    private trTrainingDetailM_Repo dmRepo = new trTrainingDetailM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            lblID.Text = Request.QueryString["ID"].ToString();
        }
        else
            throw new ApplicationException("無輸入課程ID");
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        int errCounter = 0;

        if (rbl.SelectedItem == null)
        {
            AlertMsg("未選擇寄送項目");
            return;
        }

        RadButton btn = sender as RadButton;
        string subject, content;
        MailNotify mailNotify = new MailNotify();
        mailNotify.juser = Juser;

        DoHelper doHelper = new DoHelper();

        if (btn.Text.Equals("預覽"))
            pnView.Visible = true;
        else
            pnView.Visible = false;

        int id = Convert.ToInt32(lblID.Text);

        trTrainingDetailM dm = dmRepo.GetByKey_DLO(id);
        if (dm != null)
            mailNotify.mailVariable.TDM = dm;

        //講師
        if (rbl.SelectedValue.Equals("1"))
        {
            var teachers = (from c in dcTraining.trAttendClassTeacher
                            join t in dcTraining.trTeacher on c.sTeacherCode equals t.sCode
                            where c.iClassAutoKey == id
                            select t).ToList();

            foreach (var t in teachers)
            {
                mailNotify.Email.Clear();

                if (t.sEmail == null || !MailVariable.IsEmail(t.sEmail))
                {
                    trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                    trErrorNotify errorNotifyAdmin = new trErrorNotify();
                    errorNotifyAdmin.ErrorMsg = "講師:" + t.sName + "未設定Email，未通知";
                    errorNotifyAdmin.NotifyDate = DateTime.Now;
                    errorNotifyAdmin.sKeyMan = User.Identity.Name;
                    errorNotifyAdmin.TargetNobr = null;
                    errorNotifyAdmin.TargetRole = 1;
                    errorNotifyRepo.Add(errorNotifyAdmin);
                    errorNotifyRepo.Save();

                    continue;
                }
                mailNotify.SetTrainingDetailM(id);
                //mailNotify.SetNobr(s.c.sNobr);
                mailNotify.Email.Add(t.sEmail);
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
        }
        //所有學員
        else if (rbl.SelectedValue.Equals("2"))
        {
            var smList = smRepo.GetByClassID_DLO(id);
            var tmpList = Filter_rblStudentProperty(smList);

            foreach (var s in tmpList)
            {
                mailNotify.Email.Clear();

                if (s.BASE.EMAIL == null || !MailVariable.IsEmail(s.BASE.EMAIL))
                {
                    trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                    trErrorNotify errorNotifyAdmin = new trErrorNotify();
                    errorNotifyAdmin.ErrorMsg = "工號:" + s.BASE.NOBR + "(" + s.BASE.NAME_C + ")" + "未設定Email，學員未通知";
                    errorNotifyAdmin.NotifyDate = DateTime.Now;
                    errorNotifyAdmin.sKeyMan = User.Identity.Name;
                    errorNotifyAdmin.TargetNobr = null;
                    errorNotifyAdmin.TargetRole = 1;
                    errorNotifyRepo.Add(errorNotifyAdmin);
                    errorNotifyRepo.Save();
                    continue;
                }

                mailNotify.SetTrainingDetailM(id);
                mailNotify.SetNobr(s.BASE.NOBR);
                mailNotify.Email.Add(s.BASE.EMAIL);
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
        }
        //如果是上課出席學員
        else if (rbl.SelectedValue.Equals("3") || rbl.SelectedValue.Equals("4")
            || rbl.SelectedValue.Equals("5") || rbl.SelectedValue.Equals("6"))
        {
            var smList = smRepo.GetByClassID_WithPresence_DLO(id);
            var tmpList = Filter_rblStudentProperty(smList);

            foreach (var s in tmpList)
            {
                mailNotify.Email.Clear();

                if (s.BASE.EMAIL == null || !MailVariable.IsEmail(s.BASE.EMAIL))
                {
                    trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                    trErrorNotify errorNotifyAdmin = new trErrorNotify();
                    errorNotifyAdmin.ErrorMsg = "工號:" + s.BASE.NOBR + "(" + s.BASE.NAME_C + ")" + "未設定Email，未通知";
                    errorNotifyAdmin.NotifyDate = DateTime.Now;
                    errorNotifyAdmin.sKeyMan = User.Identity.Name;
                    errorNotifyAdmin.TargetNobr = null;
                    errorNotifyAdmin.TargetRole = 1;
                    errorNotifyRepo.Add(errorNotifyAdmin);
                    errorNotifyRepo.Save();

                    continue;
                }
                mailNotify.SetTrainingDetailM(id);
                mailNotify.SetNobr(s.BASE.NOBR);
                mailNotify.Email.Add(s.BASE.EMAIL);

                List<BASETTS> managers = new List<BASETTS>();

                if (rbl.SelectedValue.Equals("4"))
                    managers = ttsRepo.GetDeptManagerByNobrDeptLevel(s.BASE.NOBR, 0);
                else if (rbl.SelectedValue.Equals("5"))
                    managers = ttsRepo.GetDeptManagerByNobrDeptLevel(s.BASE.NOBR, 1);
                else if (rbl.SelectedValue.Equals("6"))
                    managers = ttsRepo.GetDeptManagerByNobrDeptLevel(s.BASE.NOBR, 2);

                foreach (var m in managers)
                {
                    if (m.BASE.EMAIL == null || !MailVariable.IsEmail(m.BASE.EMAIL))
                    {
                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
                        errorNotifyAdmin.ErrorMsg = "工號:" + m.BASE.NOBR + "(" + m.BASE.NAME_C + ")" + "未設定Email，主管未通知";
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
            }
        }

        if (!btn.Text.Equals("預覽"))
        {
            if (errCounter > 0)
                RadAjaxPanel1.Alert("寄送信件有" + errCounter.ToString() + "筆錯誤，請檢視郵件紀錄");
            else
                RadAjaxPanel1.Alert("已寄送");
        }
    }


    private List<trTrainingStudentM> Filter_rblStudentProperty(List<trTrainingStudentM> list)
    {
        if (rblStudentProperty.SelectedValue.Equals("2"))
            return smRepo.GetNeedToFillClassRpt(list);
        else if (rblStudentProperty.SelectedValue.Equals("3"))
            return smRepo.GetNeedToFillQuestionary(list);
        else
            return list;
    }



    protected void rbl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!rbl.SelectedValue.ToString().Equals("1"))
            rblStudentProperty.Visible = true;
        else
            rblStudentProperty.Visible = false;
    }
}