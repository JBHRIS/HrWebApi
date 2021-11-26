using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Teacher_ScoreStudentReport2 : JBWebPage
{
    trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //trTrainingStudentM的Id
            if (Request.QueryString["ID"] == null)
                throw new ApplicationException("無傳正確參數");

            lblTsmId.Text = Request.QueryString["ID"].ToString();

            var tsmObj= tsmRepo.GetByPk_DLO(Convert.ToInt32(lblTsmId.Text));

            lblCate.Text = tsmObj.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName;
            lblCourse.Text = tsmObj.trTrainingDetailM.trCourse.sName;
            lblClassDate.Text = tsmObj.trTrainingDetailM.dDateA.Value.ToShortDateString();

            loadData(Convert.ToInt32(lblTsmId.Text));
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        //pnlWrite.Visible = false;

        var studentMObj = tsmRepo.GetByPk_DLO(Convert.ToInt32(lblTsmId.Text));

            if (studentMObj != null)
            {
                if (ntbScore.Value.HasValue)
                {
                    studentMObj.iNote2Score = Convert.ToInt32(ntbScore.Value);
                    studentMObj.dNote2ScoreKeyDate = DateTime.Now;
                }
                studentMObj.sNote4 = edtTeacher.Content;
                tsmRepo.Update(studentMObj);
                tsmRepo.Save();
                RadScriptManager.RegisterStartupScript(this, typeof(Page), this.GetType().ToString(), "CloseAndRebind();", true);                
            }
    }



    private void loadData(int id)
    {
        var studentMObj = tsmRepo.GetByPk_DLO(Convert.ToInt32(lblTsmId.Text));

        if (studentMObj != null)
        {
            lb_Name.Text = studentMObj.BASE.NAME_C;
            edtStudent.Content = studentMObj.sNote2;
            edtTeacher.Content = studentMObj.sNote4;
            if (studentMObj.iNote2Score.HasValue)
            {
                ntbScore.Text = studentMObj.iNote2Score.Value.ToString();
            }

            //退件按鈕顯示
            btnRejection.Enabled = false;
            if (!studentMObj.dNote2ScoreKeyDate.HasValue && studentMObj.dNote2KeyDate.HasValue)
            {
                btnRejection.Enabled = true;
            }

            if (studentMObj.dNote2KeyDate.HasValue)
            {
                lblMsg.Text = "";
                btnSend.Enabled = true;
            }
            else
            {
                lblMsg.Text = "學員尚未填寫心得";
                btnSend.Enabled = false;
            }
        }

        if (Request.QueryString["Mode"] != null && Request.QueryString["Mode"].ToString().Equals("View"))
        {
            setMode(false);
        }
        
    }

    private void setMode(bool isWritable)
    {
        if (!isWritable)
        {
            btnSend.Enabled = false;
            btnRejection.Enabled = false;
        }
    }


    protected void btnRejection_Click(object sender, EventArgs e)
    {
        trTrainingStudentM obj = tsmRepo.GetByPk_DLO(Convert.ToInt32(lblTsmId.Text));

        if (obj != null)
        {
            obj.dNote2KeyDate = null;
            obj.iScore = null;
            tsmRepo.Update(obj);

            trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo(tsmRepo.dc);
            trErrorNotify errorNotifyAdmin = new trErrorNotify();
            errorNotifyAdmin.ErrorMsg = "學員" + obj.BASE.NAME_C + obj.BASE.N_NOBR + "，"
                + obj.trTrainingDetailM.dDateA.Value.ToShortDateString() + obj.trTrainingDetailM.trCourse.sName
                + "心得被退件";
            errorNotifyAdmin.NotifyDate = DateTime.Now;
            errorNotifyAdmin.sKeyMan = User.Identity.Name;
            errorNotifyAdmin.TargetNobr = null;
            errorNotifyAdmin.TargetRole = 1;
            errorNotifyRepo.Add(errorNotifyAdmin);
            tsmRepo.Save();

            if (obj.BASE.EMAIL == null || !MailVariable.IsEmail(obj.BASE.EMAIL))
            {

                trErrorNotify errorNotifyObj = new trErrorNotify();
                errorNotifyObj.ErrorMsg = "學員:" + obj.BASE.NAME_C + obj.trTrainingDetailM.dDateA.Value.ToShortDateString()
                    + obj.trTrainingDetailM.trCourse.sName
                    + "未設定Email，心得退件未通知";
                errorNotifyObj.NotifyDate = DateTime.Now;
                errorNotifyObj.sKeyMan = User.Identity.Name;
                errorNotifyObj.TargetNobr = null;
                errorNotifyObj.TargetRole = 1;
                errorNotifyRepo.Add(errorNotifyObj);
                errorNotifyRepo.Save();
            }
            else
            {
                mtCode_Repo mtCodeRepo = new mtCode_Repo();
                mtCode mtCodeObj = mtCodeRepo.GetByCategroyCode("MailNotify", "ClassReportRejection");

                if (mtCodeObj != null)
                {
                    trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
                    MailNotify mailNotify = new MailNotify();
                    mailNotify.mailVariable.Nobr = obj.BASE.N_NOBR;
                    mailNotify.mailVariable.TrainingDetailM = obj.iClassAutoKey;
                    mailNotify.mailVariable.TDM = tdmRepo.GetByKey_DLO(obj.iClassAutoKey);
                    mailNotify.Email.Clear();
                    mailNotify.Email.Add(obj.BASE.EMAIL);
                    mailNotify.SetMailTemplate(Convert.ToInt32(mtCodeObj.s1));
                    mailNotify.SendMail();
                }
            }

            RadScriptManager.RegisterStartupScript(this, typeof(Page), this.GetType().ToString(), "CloseAndRebind();", true);
        }
    }

}