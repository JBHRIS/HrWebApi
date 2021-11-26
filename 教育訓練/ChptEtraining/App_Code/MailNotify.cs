using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Repo;
/// <summary>
/// MailNotify 的摘要描述
/// </summary>
public class MailNotify
{
    private MailLog_Repo mailLogRepo = new MailLog_Repo();
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private int MailTemplateTemplateID;
    private bool hasMailSubjectVar;
    private bool hasMailContentVar;
    private string mailSubject;
    private string mailContent;
    //private MailVariable mailVariable = new MailVariable();
    public JUser juser
    {
        set
        {
            mailVariable.juser = value;
        } 
    }
    private MailMessage mailMessage = new MailMessage();
    private SmtpClient smtpClient = new SmtpClient();
    //private string Email;
    public List<string> Email { get; set; }
    public MailVariable mailVariable { get; set; }
    public MailNotify()
    {
        MailSetting mailSetting = new MailSetting();
        //SmtpClient smtpClient = new SmtpClient(mailSetting.SmtpServer, mailSetting.SmtpPort);
        smtpClient.Host = mailSetting.SmtpServer;
        smtpClient.Port = mailSetting.SmtpPort;
        smtpClient.Credentials = new System.Net.NetworkCredential(mailSetting.SmtpUser, mailSetting.SmtpPassword);
        mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8; ;
        mailMessage.IsBodyHtml = true;
        mailMessage.From = new MailAddress(mailSetting.SmtpUser, mailSetting.MailFrom);

        mailVariable = new MailVariable();
        Email = new List<string>();

        //var mailTpl = (from c in dcTraining.trMailTemplate
        //               where c.iAutoKey == TemplateID
        //               where c.iAutoKey == Convert.ToInt32(mailNotify.s1)
        //               select c).FirstOrDefault();
    }

    public void HasMailVariable()
    {
        var mailTpl = (from c in dcTraining.trMailTemplate
                       where c.iAutoKey == MailTemplateTemplateID
                       select c).FirstOrDefault();

        if (mailTpl == null)
            throw new ApplicationException("無此通知範本");

        hasMailSubjectVar = HasVaribles(mailTpl.sMailSubject);
        hasMailContentVar = HasVaribles(mailTpl.sMailContent);

        mailSubject = mailTpl.sMailSubject;
        mailContent = mailTpl.sMailContent;
    }


    public bool HasVaribles(string str)
    {
        bool result = false;
        //MailVariable mailVariable = new MailVariable();
        string[] variablesArr = MailVariable.GetVariablesArr();

        foreach (var s in variablesArr)
        {
            if (str.Contains(s))
            {
                return true;
            }
        }

        return result;
    }

    public void SetTrainingDetailM(int id)
    {
        mailVariable.TrainingDetailM = id;
    }

    //public void SetMail(string mail)
    //{
    //    Email = mail;
    //}

    public void SetTeacher(string teacher)
    {

    }

    public void SetNobr(string nobr)
    {
        mailVariable.Nobr = nobr;
    }

    public void SetMailTemplate(int id)
    {
        MailTemplateTemplateID = id;
        HasMailVariable();
    }

    public bool SendMail()
    {
        if (MailTemplateTemplateID == 0)        
            throw new ApplicationException("未設定郵件樣板");        

        mailMessage.Subject = mailVariable.GetAllStr(mailSubject);
        mailMessage.Body = mailVariable.GetAllStr(mailContent);

        string addresses  ="";
        mailMessage.To.Clear();

        foreach (var em in Email)
        {
            mailMessage.To.Add(em);
            addresses = addresses + em +";";
        }

        MailLog mailLog = new MailLog();
        mailLog.dKeyDate = DateTime.Now;
        mailLog.MailAddressee = addresses;
        mailLog.MailContent = mailMessage.Body;
        mailLog.MailSubject = mailMessage.Subject;
        mailLog.MailTemplate = MailTemplateTemplateID;        

        try
        {
            smtpClient.Send(mailMessage);
        }
        catch(Exception ex)
        {
            if (ex.InnerException != null)
                mailLog.ErrorMsg = ex.Message + ex.InnerException.Message;
            else
                mailLog.ErrorMsg = ex.Message;

            mailLogRepo.Add(mailLog);
            mailLogRepo.Save();
            return false;
        }

        mailLogRepo.Add(mailLog);
        mailLogRepo.Save();
        return true;
    }

    public void Preview(out string subject, out string content)
    {
        if (MailTemplateTemplateID == 0)
        {
            throw new ApplicationException("未設定郵件樣板");
        }

        subject = mailVariable.GetAllStr(mailSubject);
        content = mailVariable.GetAllStr(mailContent);
    }
}