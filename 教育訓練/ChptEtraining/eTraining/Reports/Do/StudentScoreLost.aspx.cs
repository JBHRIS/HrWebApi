using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Reports_Do_StudentScoreLost:JBWebPage
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
            rdpAdate.SelectedDate = new DateTime(DateTime.Now.Year, 1, 1);
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
        string fileName = rdpAdate.SelectedDate.Value.ToShortDateString() + "~" + rdpDdate.SelectedDate.Value.ToShortDateString() + "學員評分未填寫";
        gv.ExportSettings.FileName = fileName;
        gv.MasterTableView.ExportToExcel();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gv.Visible = true;
        gv.Rebind();
    }
    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
        {
            e.Item.Visible = false;
        }
    }
    protected void gv_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason != GridRebindReason.InitialLoad)
        {
            trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
            var list = tsmRepo.GetNeedStudentScoreByDateRangeWithTeacherKeyDateNull_DLO(rdpAdate.SelectedDate.Value, rdpDdate.SelectedDate.Value);
            ClassTeacher_Repo classTeacherRepo = new ClassTeacher_Repo();

            gv.DataSource = (from c in list
                             select new
                             {
                                 iAutoKey = c.iAutoKey,
                                 //catName = c.trTrainingDetailM.trCategory.sName,
                                 catName = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                 courseAdate = c.trTrainingDetailM.dDateTimeA,
                                 courseCode = c.trTrainingDetailM.trCourse_sCode,
                                 courseName = c.trTrainingDetailM.trCourse.sName,
                                 D_NO = c.BASE.BASETTS[0].DEPT,
                                 D_NAME = c.BASE.BASETTS[0].DEPT1.D_NAME,
                                 NAME_C = c.BASE == null ? "" : c.BASE.NAME_C,
                                 teacherName = classTeacherRepo.GetAllTeacherName(c.trTrainingDetailM.ClassTeacher.ToList())
                             }).ToList();
        }       
    }





    protected void btnSend_Click(object sender, EventArgs e)
    {
        int errCounter = 0;
        RadButton btn = sender as RadButton;
        string subject, content;
        MailNotify mailNotify = new MailNotify();
        DoHelper doHelper = new DoHelper();

        if (rbl.SelectedItem == null)
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
        List<int> haveSentClass = new List<int>();

        foreach (GridDataItem item in gv.Items)
        {
            trTrainingStudentM sm = smRepo.GetByPkWithPresence_DLO(Convert.ToInt32(item["iAutoKey"].Text));
            trTrainingDetailM dm = dmRepo.GetByKey_DLO(sm.iClassAutoKey);
            if (dm != null)
                mailNotify.mailVariable.TDM = dm;

            //講師
            if (rbl.SelectedValue.Equals("1"))
            {
                //發送講師時，已發送的課程就不發
                if (haveSentClass.Contains(dm.iAutoKey))
                    continue;
                else
                    haveSentClass.Add(dm.iAutoKey);

                var teachers = (from c in dcTraining.trAttendClassTeacher
                                join t in dcTraining.trTeacher on c.sTeacherCode equals t.sCode
                                where c.iClassAutoKey == dm.iAutoKey
                                select t).ToList();

                foreach (var t in teachers)
                {
                    mailNotify.Email.Clear();

                    if (t.sEmail == null || !MailVariable.IsEmail(t.sEmail))
                    {
                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
                        errorNotifyAdmin.ErrorMsg = "講師:" + t.sName + "未設定Email，未通知。";
                        errorNotifyAdmin.NotifyDate = DateTime.Now;
                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
                        errorNotifyAdmin.TargetNobr = null;
                        errorNotifyAdmin.TargetRole = 1;
                        errorNotifyRepo.Add(errorNotifyAdmin);
                        errorNotifyRepo.Save();

                        continue;
                    }
                    mailNotify.SetTrainingDetailM(dm.iAutoKey);
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
        }

        if (!btn.Text.Equals("預覽"))
        {
            if (errCounter > 0)
                AlertMsg("寄送信件有" + errCounter.ToString() + "筆錯誤，請檢視郵件紀錄");
            else
                AlertMsg("已寄送");
        }
    }
}