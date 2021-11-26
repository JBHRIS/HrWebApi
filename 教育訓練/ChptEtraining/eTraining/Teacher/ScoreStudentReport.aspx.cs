using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Teacher_ScoreStudentReport : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] == null)
                throw new ApplicationException("無傳正確參數");

            lbliClassAutokey.Text = Request.QueryString["ID"].ToString();

            var lbl = (from m in dcTrain.trTrainingDetailM
                       join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                       join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
                       join d in dcTrain.trAttendClassDate on m.iAutoKey equals d.iClassAutoKey
                       where m.iAutoKey == Convert.ToInt32(lbliClassAutokey.Text)
                       select new
                       {
                           caName = ca.sName,
                           coName = co.sName,
                           dDate = d.dClassDate,
                           dStudentScoreDeadline = m.dStudentScoreDeadline
                       }).FirstOrDefault();

            lblCate.Text = lbl.caName;
            lblCourse.Text = lbl.coName;
            lblClassDate.Text = lbl.dDate.ToShortDateString();

            if (GetRequestQueryStringValue("Mode").ToUpper().Equals("M"))
            {
                hlBack.NavigateUrl = @"~/eTraining/Manager/ManagerWrite.aspx";
            }

            //在心得該頁也顯示課名及學員姓名
            //lb_Course.Text = "課程:" + lblCourse.Text;

            //檢查是否超過時間
            //if (lbl.dStudentScoreDeadline.HasValue && lbl.dStudentScoreDeadline.Value < DateTime.Now)
            //{
            //    lblClassMsg.Text = "已超過填寫日期期限"+lbl.dStudentScoreDeadline.Value.ToShortDateString();
            //    gv.Enabled = false;
            //}
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        pnlView.Visible = true;
        pnlWrite.Visible = false;

        int id = Convert.ToInt32(gv.SelectedValue.ToString());

        var studentMObj = (from c in dcTrain.trTrainingStudentM
                           where c.iAutoKey == id
                           select c).FirstOrDefault();

        if (studentMObj != null)
        {
            if (ntbScore.Value.HasValue)
            {
                studentMObj.iNote2Score = Convert.ToInt32(ntbScore.Value);
                studentMObj.dNote2ScoreKeyDate = DateTime.Now;
            }
            studentMObj.sNote4 = edtTeacher.Content;
            dcTrain.SubmitChanges();
        }
        cleanData();
        gv.Rebind();
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item["dNote2KeyDate"].Text.Trim().Length == 0)
            {
                item["dNote2KeyDate"].Text = "尚未填寫";
                item["dNote2KeyDate"].ForeColor = System.Drawing.Color.Red;
            }

            if (item["bPresence"].Text.Trim().ToUpper().Equals("FALSE"))
            {
                item["Select"].Text = "未出席";
                item["Select"].ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        //RadWindow1.VisibleOnPageLoad = true;
        pnlWrite.Visible = true;
        pnlView.Visible = false;
        int id = Convert.ToInt32(gv.SelectedValue.ToString());
        cleanData();
        loadData(id);
    }

    private void loadData(int id)
    {
        var studentMObj = (from c in dcTrain.trTrainingStudentM
                           where c.iAutoKey == id
                           select c).FirstOrDefault();

        if (studentMObj != null)
        {
            lb_Name.Text = (from c in dcTrain.BASE
                            where c.NOBR == studentMObj.sNobr
                            select c.NAME_C).FirstOrDefault();
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
    }

    private void cleanData()
    {
        edtStudent.Content = "";
        ntbScore.Text = "";
        edtTeacher.Content = "";
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        pnlView.Visible = true;
        pnlWrite.Visible = false;
    }

    protected void btnRejection_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(gv.SelectedValue.ToString());

        trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        trTrainingStudentM obj = tsmRepo.GetByPk_DLO(id);

        if (obj != null)
        {
            obj.dNote2KeyDate = null;
            obj.iScore = null;
            tsmRepo.Update(obj);

            trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo(tsmRepo.dc);
            trErrorNotify errorNotifyAdmin = new trErrorNotify();
            errorNotifyAdmin.ErrorMsg = "學員" + obj.BASE.NAME_C + obj.BASE.NOBR + "，"
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

            //trErrorNotify errorNotifyStu = new trErrorNotify();
            //errorNotifyStu.ErrorMsg = "您於課程：" + obj.trTrainingDetailM.dDateA.Value.ToShortDateString() + obj.trTrainingDetailM.trCourse.sName
            //    + "心得被退件，請重填";
            //errorNotifyStu.NotifyDate = DateTime.Now;
            //errorNotifyStu.sKeyMan = User.Identity.Name;
            //errorNotifyStu.TargetNobr = obj.sNobr;
            //errorNotifyStu.TargetRole = null;
            //errorNotifyRepo.Add(errorNotifyStu);

            cleanData();
            gv.Rebind();
            pnlView.Visible = true;
            pnlWrite.Visible = false;
        }
    }
    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        int id = 0;
        Int32.TryParse(GetRequestQueryStringValue("ID"), out id);

        //如果是主管功能的頁面
        if (GetRequestQueryStringValue("Mode").ToUpper().Equals("M"))
        {
            var list = (from c in tsmRepo.GetByClassID_DLO(id)
                        select new
                        {
                            iAutoKey = c.iAutoKey,
                            sDeptCode = c.sDeptCode,
                            dNote2ScoreKeyDate = c.dNote2ScoreKeyDate,
                            dNote2KeyDate = c.dNote2KeyDate,
                            iNote2Score = c.iNote2Score,
                            NAME_C = c.BASE.NAME_C,
                            sNote1 = c.sNote1,
                            sNote3 = c.sNote3,
                            nobr = c.sNobr,
                            iScore = c.iScore,
                            dTeacherKeyDate = c.dTeacherKeyDate,
                            bPresence = c.bPresence,
                            IsHired = BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(c.BASE.BASETTS[0].TTSCODE)
                        }).ToList();

            gv.DataSource = list.Where(p => Juser.ManageEmpList.Contains(p.nobr)).ToList();
            //gv.DataSource = list.Where(p => p.sDeptCode == Juser.Dept).ToList();
        }
        else
            gv.DataSource = (from c in tsmRepo.GetByClassID_DLO(id)
                             select new
                             {
                                 iAutoKey = c.iAutoKey,
                                 sDeptCode = c.sDeptCode,
                                 dNote2ScoreKeyDate = c.dNote2ScoreKeyDate,
                                 dNote2KeyDate = c.dNote2KeyDate,
                                 iNote2Score = c.iNote2Score,
                                 NAME_C = c.BASE.NAME_C,
                                 sNote1 = c.sNote1,
                                 sNote3 = c.sNote3,
                                 iScore = c.iScore,
                                 dTeacherKeyDate = c.dTeacherKeyDate,
                                 bPresence = c.bPresence,
                                 IsHired = BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(c.BASE.BASETTS[0].TTSCODE)
                             }).ToList();
    }
}