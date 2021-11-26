using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Repo;
public partial class eTraining_Admin_Plan_PlanSurveyMail : JBWebPage
{    
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbYear);
        }
        this.Title = "產生年度需求&寄Mail";
    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        //模組三的版本
        try
        {
            DoHelper doHelper = new DoHelper();

            var mailNotify = (from c in dcTraining.mtCode
                              where c.sCategory == "MailNotify" && c.sCode == "Question"
                              select c).FirstOrDefault();

            if (mailNotify == null || mailNotify.s1 == "0")
            {
                AlertMsg("還未設定郵件樣板");
                return;
            }

            //取得mail 設定值
            MailSetting mailSetting = new MailSetting();

            SmtpClient smtpClient = new SmtpClient(mailSetting.SmtpServer, mailSetting.SmtpPort);
            MailVariable mailVariable = new MailVariable();

            var mailTpl = (from c in dcTraining.trMailTemplate
                           where c.iAutoKey == Convert.ToInt32(mailNotify.s1)
                           select c).FirstOrDefault();

            //郵件是否有設定變數                       
            bool hasMailSubjectVar = mailVariable.hasVaribles(mailTpl.sMailSubject);
            bool hasMailContentVar = mailVariable.hasVaribles(mailTpl.sMailContent);

            smtpClient.Credentials = new System.Net.NetworkCredential(mailSetting.SmtpUser, mailSetting.SmtpPassword);

            MailMessage mailMessage = new MailMessage();
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8; ;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(mailSetting.SmtpUser, mailSetting.MailFrom);

            int year = Convert.ToInt32(cbYear.SelectedValue);
            QuestDept_Repo qdRepo = new QuestDept_Repo();
            List<QuestDept> qdList = qdRepo.GetByYear(year);
            DEPT_Repo deptRepo = new DEPT_Repo();


            //如果有範本中變數的話，就是一封一封寄信給使用者
            if (hasMailSubjectVar || hasMailContentVar)
            {
                foreach (var i in qdList)
                {
                    DEPT deptObj = deptRepo.GetById_BASE_Dlo(i.DeptCode);
                    if (deptObj.BASE == null)
                        continue;

                    if (deptObj.BASE.EMAIL != null && MailVariable.IsEmail(deptObj.BASE.EMAIL))
                    {
                        mailMessage.To.Clear();
                        string mailSubject = mailTpl.sMailSubject;
                        string mailContent = mailTpl.sMailContent;

                        if (hasMailSubjectVar)
                        {
                            mailVariable.Nobr = deptObj.BASE.NOBR;
                            mailSubject = mailVariable.GetBaseStr(mailSubject);
                        }

                        if (hasMailContentVar)
                        {
                            mailVariable.Nobr = deptObj.BASE.NOBR;
                            mailContent = mailVariable.GetBaseStr(mailContent);
                        }

                        mailMessage.Subject = mailSubject;
                        mailMessage.Body = mailContent;
                        mailMessage.To.Add(deptObj.BASE.EMAIL);
                        smtpClient.Send(mailMessage);

                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
                        errorNotifyAdmin.ErrorMsg = "您有新年度的課程調查需求需填寫";
                        errorNotifyAdmin.NotifyDate = DateTime.Now;
                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
                        errorNotifyAdmin.TargetNobr = deptObj.BASE.NOBR;
                        errorNotifyAdmin.TargetRole = null;
                        errorNotifyRepo.Add(errorNotifyAdmin);
                        errorNotifyRepo.Save();
                    }
                    else
                    {
                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
                        errorNotifyAdmin.ErrorMsg = "工號:" + deptObj.BASE.NOBR + "(" + deptObj.BASE.NAME_C + ")" + "未設定Email，年度需求調查填寫通知未通知";
                        errorNotifyAdmin.NotifyDate = DateTime.Now;
                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
                        errorNotifyAdmin.TargetNobr = null;
                        errorNotifyAdmin.TargetRole = 1;
                        errorNotifyRepo.Add(errorNotifyAdmin);
                        errorNotifyRepo.Save();
                    }
                }

            }
            else//如果信件範本沒有變數，則寄一封信給大家就好
            {
                mailMessage.Subject = mailTpl.sMailSubject;
                mailMessage.Body = mailTpl.sMailSubject;

                foreach (var i in qdList)
                {
                    DEPT deptObj = deptRepo.GetById_BASE_Dlo(i.DeptCode);
                    if (deptObj.BASE == null)
                        continue;

                    if (deptObj.BASE.EMAIL != null && MailVariable.IsEmail(deptObj.BASE.EMAIL))
                    {
                        mailMessage.To.Add(deptObj.BASE.EMAIL);
                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotify = new trErrorNotify();
                        errorNotify.ErrorMsg = "您有新年度的課程調查需求需填寫";
                        errorNotify.NotifyDate = DateTime.Now;
                        errorNotify.sKeyMan = User.Identity.Name;
                        errorNotify.TargetNobr = deptObj.BASE.NOBR;
                        errorNotify.TargetRole = null;
                        errorNotifyRepo.Add(errorNotify);
                        errorNotifyRepo.Save();
                    }
                    else
                    {
                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
                        errorNotifyAdmin.ErrorMsg = "工號:" + deptObj.BASE.NOBR + "(" + deptObj.BASE.NAME_C + ")" + "未設定Email，年度需求調查填寫通知未通知";
                        errorNotifyAdmin.NotifyDate = DateTime.Now;
                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
                        errorNotifyAdmin.TargetNobr = null;
                        errorNotifyAdmin.TargetRole = 1;
                        errorNotifyRepo.Add(errorNotifyAdmin);
                        errorNotifyRepo.Save();
                    }
                }

                smtpClient.Send(mailMessage);
            }

        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message+"錯誤，請聯絡資訊人員");
        }

        AlertMsg("寄送完成");

        //最早期版本-模組一
//        try
//        {
//        DoHelper doHelper = new DoHelper();

//        var mailNotify = (from c in dcTraining.mtCode
//                          where c.sCategory == "MailNotify" && c.sCode == "Question"
//                          select c).FirstOrDefault();

//        if (mailNotify == null || mailNotify.s1 == "0")
//        {
//            AlertMsg("還未設定郵件樣板");
//            return;
//        }

//        //取得mail 設定值
//        MailSetting mailSetting = new MailSetting();

//        SmtpClient smtpClient = new SmtpClient(mailSetting.SmtpServer, mailSetting.SmtpPort);
//        MailVariable mailVariable = new MailVariable();

//        var mailTpl = (from c in dcTraining.trMailTemplate where c.iAutoKey == Convert.ToInt32(mailNotify.s1)
//                       select c).FirstOrDefault();

//        //郵件是否有設定變數                       
//        bool hasMailSubjectVar = mailVariable.hasVaribles(mailTpl.sMailSubject);
//        bool hasMailContentVar = mailVariable.hasVaribles(mailTpl.sMailContent);

//        smtpClient.Credentials = new System.Net.NetworkCredential(mailSetting.SmtpUser,mailSetting.SmtpPassword);
                
//        MailMessage mailMessage = new MailMessage();
//        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
//        mailMessage.BodyEncoding = System.Text.Encoding.UTF8; ;
//        mailMessage.IsBodyHtml = true;
//        mailMessage.From = new MailAddress(mailSetting.SmtpUser, mailSetting.MailFrom);
        
//        var userList = from s in dcTraining.trTrainingStudentD
//                       join b in dcTraining.BASE on s.sNobr equals b.NOBR
////                       where b.EMAIL != null && b.EMAIL.Length > 0
//                       select new { s, b };


//            //如果有範本中變數的話，就是一封一封寄信給使用者
//            if (hasMailSubjectVar || hasMailContentVar)
//            {
//                foreach (var i in userList)
//                {
//                    if (i.b.EMAIL != null && MailVariable.IsEmail(i.b.EMAIL))
//                    {
//                        mailMessage.To.Clear();
//                        string mailSubject = mailTpl.sMailSubject;
//                        string mailContent = mailTpl.sMailContent;

//                        if (hasMailSubjectVar)
//                        {                         
//                            mailVariable.Nobr = i.s.sNobr;
//                            mailSubject = mailVariable.GetBaseStr(mailSubject);
//                        }

//                        if (hasMailContentVar)
//                        {
//                            mailVariable.Nobr = i.s.sNobr;
//                            mailContent = mailVariable.GetBaseStr(mailContent);
//                        }

//                        mailMessage.Subject = mailSubject;
//                        mailMessage.Body = mailContent;
//                        mailMessage.To.Add(i.b.EMAIL);
//                        smtpClient.Send(mailMessage);

//                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
//                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
//                        errorNotifyAdmin.ErrorMsg = "您有新年度的課程調查需求需填寫";
//                        errorNotifyAdmin.NotifyDate = DateTime.Now;
//                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
//                        errorNotifyAdmin.TargetNobr = i.b.NOBR;
//                        errorNotifyAdmin.TargetRole = null;
//                        errorNotifyRepo.Add(errorNotifyAdmin);
//                        errorNotifyRepo.Save();
//                    }
//                    else
//                    {
//                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
//                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
//                        errorNotifyAdmin.ErrorMsg = "工號:" + i.b.NOBR + "("+i.b.NAME_C+")"+"未設定Email，年度需求調查填寫通知未通知";
//                        errorNotifyAdmin.NotifyDate = DateTime.Now;
//                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
//                        errorNotifyAdmin.TargetNobr = null;
//                        errorNotifyAdmin.TargetRole = 1;
//                        errorNotifyRepo.Add(errorNotifyAdmin);
//                        errorNotifyRepo.Save();
//                    }
//                }

//            }
//            else//如果信件範本沒有變數，則寄一封信給大家就好
//            {
//                mailMessage.Subject = mailTpl.sMailSubject;
//                mailMessage.Body = mailTpl.sMailSubject;

//                foreach (var i in userList)
//                {
//                    if (i.b.EMAIL != null && MailVariable.IsEmail(i.b.EMAIL))
//                    {
//                        mailMessage.To.Add(i.b.EMAIL);
//                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
//                        trErrorNotify errorNotify = new trErrorNotify();
//                        errorNotify.ErrorMsg = "您有新年度的課程調查需求需填寫";
//                        errorNotify.NotifyDate = DateTime.Now;
//                        errorNotify.sKeyMan = User.Identity.Name;
//                        errorNotify.TargetNobr = i.b.NOBR;
//                        errorNotify.TargetRole = null;
//                        errorNotifyRepo.Add(errorNotify);
//                        errorNotifyRepo.Save();
//                    }
//                    else
//                    {
//                        trErrorNotify_Repo errorNotifyRepo = new trErrorNotify_Repo();
//                        trErrorNotify errorNotifyAdmin = new trErrorNotify();
//                        errorNotifyAdmin.ErrorMsg = "工號:" + i.b.NOBR + "(" + i.b.NAME_C + ")" + "未設定Email，年度需求調查填寫通知未通知";
//                        errorNotifyAdmin.NotifyDate = DateTime.Now;
//                        errorNotifyAdmin.sKeyMan = User.Identity.Name;
//                        errorNotifyAdmin.TargetNobr = null;
//                        errorNotifyAdmin.TargetRole = 1;
//                        errorNotifyRepo.Add(errorNotifyAdmin);
//                        errorNotifyRepo.Save();
//                    }
//                }

//                smtpClient.Send(mailMessage);
//            }

//        }
//        catch (Exception ex)
//        {
//            AlertMsg("錯誤，請聯絡資訊人員");
//        }

//        AlertMsg("寄送完成");
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        int year = Int32.Parse(cbYear.SelectedValue);

        trTrainingStudentD_Repo sdRepo = new trTrainingStudentD_Repo();
        var studentList = sdRepo.GetByYear(year);

        trRequirementTemplateRecord_Repo rtrRepo= new trRequirementTemplateRecord_Repo();
        var tplRecord = rtrRepo.GetByYear(year);

        if(tplRecord ==null)
            return;

        //抓取年度設定的樣板
        var ReqTplCatDtlList = (from c in dcTraining.trRequirementTemplateCatDetail
                               where c.Rt_sCode == tplRecord.Rt_sCode
                               select c).ToList();

        
        //先抓取所有user，離線處理
        var userList = (from b in dcTraining.BASE
                       join t in dcTraining.BASETTS on b.NOBR equals t.NOBR
                       join d in dcTraining.DEPT on t.DEPT equals d.D_NO
                        where DateTime.Now.Date >= t.ADATE
                       && DateTime.Now.Date <= t.DDATE
                       && DateTime.Now.Date >= d.ADATE
                       && DateTime.Now.Date <= d.DDATE &&//部門也要過濾失效的
                       new string[] { "1" , "4" , "6" }.Contains(t.TTSCODE)
                       select new
                       {
                           Nobr = b.NOBR,
                           Dept = t.DEPT,
                           Job = t.JOB,
                           JobL = t.JOBL,
                           JobS = t.JOBS,
                           Mang = t.MANG
                           //b ,
                           //t ,
                           //d
                       }).ToList();

        //抓取課程，如果有的話，離線處理
        var courseList = (from c in dcTraining.trCourse
                         select c).ToList();

        foreach(var studentItem in studentList)
        {
            foreach (var ReqTplCatDtlItem in ReqTplCatDtlList)
            {
                var user = (from c in userList
                            where c.Nobr == studentItem.sNobr
                            select c).FirstOrDefault();

                if (user != null)
                {
                    trTrainingQuest obj = new trTrainingQuest();
                    obj.iYear = year;
                    obj.sJobCode = user.Job;
                    obj.sJoblCode = user.JobL;
                    obj.sJobsCode = user.JobS;
                    obj.sDeptCode = user.Dept;
                    obj.sNobr = user.Nobr;
                    obj.trCourse_sCode = ReqTplCatDtlItem.trCourse_sCode;
                    obj.sKey = ReqTplCatDtlItem.Rtc_sCode;
                    
                    //抓取課程
                    //var courseList = from c in dcTraining.trCourse
                    //                 select c;

                    var courseItem = (from c in courseList
                                 where c.sCode == obj.trCourse_sCode
                                 select c).FirstOrDefault();

                    //var courseItem= course.FirstOrDefault();
                    if (courseItem != null)
                    {
                        obj.trCourse_sCode = courseItem.sCode;
                    }

                    //抓取部門主管
                    if (user.Dept != null)
                    {
                        var managerItem = (from c in userList
                                           where c.Dept == user.Dept
                                           && c.Mang == true
                                           select c).FirstOrDefault();

                        //var managerItem = managerList.FirstOrDefault();
                        if (managerItem != null)
                        {
                            obj.sManage = managerItem.Nobr;
                            //obj.sManage = managerItem.NOBR;
                        }
                    }

                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;

                    dcTraining.trTrainingQuest.InsertOnSubmit(obj);
                    //dcTraining.SubmitChanges();
                }
            } //foreach end

            try
            {
                dcTraining.SubmitChanges();
                AlertMsg("產生完畢");
            }
            catch (Exception ex)
            {


            }
        }//foreach end

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int year = int.Parse(cbYear.SelectedValue);

        var reqYearRecord = (from c in dcTraining.trRequirementTemplateRecord
                             where c.iYear == year && c.bIsClosed == true
                             select c).FirstOrDefault();

        if (reqYearRecord != null)
        {
            AlertMsg("需求已關閉，無法刪除");
            return;
        }
                             

        var list = (from c in dcTraining.trTrainingQuest
                   where c.iYear == year
                   select c).ToList();

        dcTraining.trTrainingQuest.DeleteAllOnSubmit(list);
        dcTraining.SubmitChanges();
        AlertMsg("刪除完畢");
    }
    protected void btnPreview_Click(object sender , EventArgs e)
    {

        try
        {
        var mailNotify = (from c in dcTraining.mtCode
                          where c.sCategory == "MailNotify" && c.sCode == "Question"
                          select c).FirstOrDefault();

        if ( mailNotify == null || mailNotify.s1 == "0" )
        {
            AlertMsg("還未設定郵件樣板");
            return;
        }

        //取得mail 設定值
        MailSetting mailSetting = new MailSetting();

        SmtpClient smtpClient = new SmtpClient(mailSetting.SmtpServer , mailSetting.SmtpPort);
        MailVariable mailVariable = new MailVariable();

        var mailTpl = (from c in dcTraining.trMailTemplate
                       where c.iAutoKey == Convert.ToInt32(mailNotify.s1)
                       select c).FirstOrDefault();

        //郵件是否有設定變數                       
        bool hasMailSubjectVar = mailVariable.hasVaribles(mailTpl.sMailSubject);
        bool hasMailContentVar = mailVariable.hasVaribles(mailTpl.sMailContent);

        smtpClient.Credentials = new System.Net.NetworkCredential(mailSetting.SmtpUser , mailSetting.SmtpPassword);

        MailMessage mailMessage = new MailMessage();
        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        mailMessage.IsBodyHtml = true;
        mailMessage.From = new MailAddress(mailSetting.SmtpUser , mailSetting.MailFrom);


        //模組3使用，發送部門主管需求通知
        int year = Convert.ToInt32(cbYear.SelectedValue);
        QuestDept_Repo qdRepo = new QuestDept_Repo();
        List<QuestDept> qdList= qdRepo.GetByYear(year);
        DEPT_Repo deptRepo = new DEPT_Repo();

            if ( hasMailSubjectVar || hasMailContentVar )
            {
                foreach ( var i in qdList )
                {
                    DEPT deptObj = deptRepo.GetById_BASE_Dlo(i.DeptCode);
                    if ( deptObj.BASE == null )
                        continue;

                    if ( deptObj.BASE.EMAIL != null && deptObj.BASE.EMAIL.Contains("@") )
                    {
                        mailMessage.To.Clear();
                        string mailSubject = mailTpl.sMailSubject;
                        string mailContent = mailTpl.sMailContent;

                        if ( hasMailSubjectVar )
                        {
                            mailVariable.Nobr = deptObj.NOBR;
                            mailSubject = mailVariable.GetBaseStr(mailSubject);
                        }

                        if ( hasMailContentVar )
                        {
                            mailVariable.Nobr = deptObj.NOBR;
                            mailContent = mailVariable.GetBaseStr(mailContent);
                        }

                        mailMessage.Subject = mailSubject;
                        mailMessage.Body = mailContent;
                        mailMessage.To.Add(deptObj.BASE.EMAIL);

                        //從這裡建立預覽資料，並離開
                        lblMailBody.Text = mailContent;
                        lblMailSubject.Text = mailSubject;
                        pnView.Visible = true;
                        return;
                    }
                    else
                    {
                        logger.Warn(deptObj.NOBR + "have no email");

                    }
                }
            }
            else
            {
                mailMessage.Subject = mailTpl.sMailSubject;
                mailMessage.Body = mailTpl.sMailSubject;

                //Preview到這邊即中斷
                lblMailBody.Text = mailTpl.sMailSubject;
                lblMailSubject.Text = mailTpl.sMailSubject;
                pnView.Visible = true;
                return;

                foreach ( var i in qdList )
                {
                    DEPT deptObj = deptRepo.GetById_BASE_Dlo(i.DeptCode);
                    if ( deptObj.BASE == null )
                        continue;

                    if ( deptObj.BASE.EMAIL != null && deptObj.BASE.EMAIL.Contains("@") )
                        mailMessage.To.Add(deptObj.BASE.EMAIL);
                    else
                    {
                        logger.Warn(deptObj.NOBR + "have no email");
                    }
                }
            }

        }
        catch ( Exception ex )
        {
            AlertMsg(ex.Message+"錯誤，請聯絡資訊人員");
        }


        //發送個人的需求通知，模組1使用的
        //var userList = from s in dcTraining.trTrainingStudentD
        //               join b in dcTraining.BASE on s.sNobr equals b.NOBR
        //               //                       where b.EMAIL != null && b.EMAIL.Length > 0
        //               select new
        //               {
        //                   s ,
        //                   b
        //               };
        //try
        //{

        //    if ( hasMailSubjectVar || hasMailContentVar )
        //    {
        //        foreach ( var i in userList )
        //        {
        //            if ( i.b.EMAIL != null && i.b.EMAIL.Contains("@") )
        //            {
        //                mailMessage.To.Clear();
        //                string mailSubject = mailTpl.sMailSubject;
        //                string mailContent = mailTpl.sMailContent;

        //                if ( hasMailSubjectVar )
        //                {///todo///
        //                    ///
        //                    mailVariable.Nobr = i.s.sNobr;
        //                    mailSubject = mailVariable.GetBaseStr(mailSubject);
        //                }

        //                if ( hasMailContentVar )
        //                {
        //                    mailVariable.Nobr = i.s.sNobr;
        //                    mailContent = mailVariable.GetBaseStr(mailContent);
        //                }

        //                mailMessage.Subject = mailSubject;
        //                mailMessage.Body = mailContent;
        //                mailMessage.To.Add(i.b.EMAIL);

        //                //smtpClient.Send(mailMessage);
        //                //從這裡建立預覽資料，並離開
        //                lblMailBody.Text = mailContent;
        //                lblMailSubject.Text = mailSubject;                       
        //                pnView.Visible = true;
        //                return;
        //                //MailSubject.TextMode = TextBoxMode.SingleLine;
        //                //MailSubject.Text = mailSubject;
                        

        //            }
        //            else
        //            {
        //                logger.Warn(i.b.NOBR + "have no email");

        //            }
        //        }

        //    }
        //    else
        //    {
        //        mailMessage.Subject = mailTpl.sMailSubject;
        //        mailMessage.Body = mailTpl.sMailSubject;

        //        //Preview到這邊即中斷
        //        lblMailBody.Text = mailTpl.sMailSubject;
        //        lblMailSubject.Text = mailTpl.sMailSubject;
        //        pnView.Visible = true;
        //        return;

        //        foreach ( var i in userList )
        //        {
        //            if ( i.b.EMAIL != null && i.b.EMAIL.Contains("@") )
        //                mailMessage.To.Add(i.b.EMAIL);
        //            else
        //            {
        //                logger.Warn(i.b.NOBR + "have no email");
        //            }
        //        }

        //        //smtpClient.Send(mailMessage);
        //    }

        //}
        //catch ( Exception ex )
        //{
        //    AlertMsg("錯誤，請聯絡資訊人員");
        //}

        AlertMsg("寄送完成");
    }
    protected void btnGenQuestDept_Click(object sender , EventArgs e)
    {
        //需求調查版本三的產生
        int year = Int32.Parse(cbYear.SelectedValue);

        trRequirementTemplateRecord_Repo rtrRepo = new trRequirementTemplateRecord_Repo();
        var tplRecord = rtrRepo.GetByYear(year);

        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        var rtcList = rtcRepo.GetByRT_CodeDlo(tplRecord.Rt_sCode);

        if ( tplRecord == null || rtcList == null )
        {
            Show("尚未設定樣板");
            return;
        }

        QuestDept_Repo qdRepo = new QuestDept_Repo();
        List<QuestDept> qdList = qdRepo.GetByYear(year);
        QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();

        foreach ( QuestDept qd in qdList )
        {
            foreach ( var rtcObj in rtcList )
            {
                QuestDeptDetail3 obj = qdd3Repo.GetByQDId_RTCId(qd.Id , rtcObj.Id);
                if ( obj == null )
                {
                    obj = new QuestDeptDetail3();
                    obj.QuestDeptId = qd.Id;
                    obj.trRequirementTemplateCourseId = rtcObj.Id;
                    qdd3Repo.Add(obj);
                }
            }
        }

        qdd3Repo.Save();
        Show("產生完成");
        //需求調查版本二的產生
        //int year = Int32.Parse(cbYear.SelectedValue);

        //trRequirementTemplateRecord_Repo rtrRepo = new trRequirementTemplateRecord_Repo();
        //var tplRecordList = rtrRepo.GetByYear(year);
        //var tplRecord = tplRecordList.FirstOrDefault();

        //trRequirementTemplateDetail_Repo rtdRepo = new trRequirementTemplateDetail_Repo();
        //var rtdList=rtdRepo.GetByTplCode(tplRecord.Rt_sCode);

        //if ( tplRecord == null || rtdList==null)
        //{
        //    Show("尚未設定樣板");
        //    return;
        //}

        //QuestDept_Repo qdRepo = new QuestDept_Repo();
        //List<QuestDept> qdList= qdRepo.GetByYear(year);
        //QuestDeptDetail_Repo qddRepo = new QuestDeptDetail_Repo();

        //foreach ( QuestDept qd in qdList )
        //{
        //    foreach ( var rtdObj in rtdList )
        //    {
        //        QuestDeptDetail obj = new QuestDeptDetail();
        //        obj.QuestDeptId = qd.Id;
        //        obj.trRequirementTemplateDetailId = rtdObj.iAutoKey;
        //        qddRepo.Add(obj);
        //    }
        //}

        //qddRepo.Save();
        //Show("產生完成");
    }
}