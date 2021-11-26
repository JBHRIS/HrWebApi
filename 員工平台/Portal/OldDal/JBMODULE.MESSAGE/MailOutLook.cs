using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Net.Mail;

namespace JBModule.Message
{
    //信件使用範例
    //CreateEmailItem(GetApplicationObject(), mailtitle, Row["email"].ToString().Trim(), "", ZipFild); 
    

    public class MailOutLook
    {
        public void CreateEmailItem(Outlook.Application application, string subjectEmail, string toEmail, string bodyEmail, string File)
        {
            Outlook.MailItem eMail = application.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
            eMail.Subject = subjectEmail;
            eMail.To = toEmail;
            eMail.Body = bodyEmail;
            eMail.Importance = Outlook.OlImportance.olImportanceLow;

            //附加附件
            //eMail.Attachments.Add(File,
            //Outlook.OlAttachmentType.olByValue, Type.Missing,
            //Type.Missing);
            ((Outlook._MailItem)eMail).Send();
        }
        public bool CreateEmailItem(string fromAddress, string fromDisName, string toAddress, string toDisName, string subject, string body, string keyMan, string File)
        {
            Mail.KEY_MAN = keyMan;
            Mail mail = new Mail();
            MailAddress to = new MailAddress(toAddress.Trim(), toDisName);
            MailAddress from = null;
            try 
            { 
                from  = new MailAddress(fromAddress.Trim(), fromDisName); 
            }
            catch
            {
                from = new MailAddress("tony@jbjob.com.tw", "JB");
            }
            try
            {
                Outlook.Application application = GetApplicationObject();
                Outlook.MailItem eMail = application.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
                eMail.Subject = subject;
                eMail.To = toAddress.Trim();
                eMail.Body = body;
                eMail.Importance = Outlook.OlImportance.olImportanceLow;

                //附加附件
                //eMail.Attachments.Add(File,
                //Outlook.OlAttachmentType.olByValue, Type.Missing,
                //Type.Missing);
                ((Outlook._MailItem)eMail).Send();
                mail.AddMailQueue(from, to, true, subject, body);
            }
            catch (Exception ex)
            {
                mail.AddMailQueue(from, to, false, subject, body);
                JBModule.Message.DbLog.key_man = keyMan;
                JBModule.Message.DbLog.WriteLog(ex, "助理系統通知信錯誤");
                return false;
            }
            return true;
        }
        public Outlook.Application GetApplicationObject()
        {

            Outlook.Application application = null;

            // Check whether there is an Outlook process running.
            if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {

                // If so, use the GetActiveObject method to obtain the process and cast it to an Application object.
                application = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
            }
            else
            {

                // If not, create a new instance of Outlook and log on to the default profile.
                application = new Outlook.Application();
                Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
                nameSpace.Logon("", "", Missing.Value, Missing.Value);
                nameSpace = null;
            }

            // Return the Outlook Application object.
            return application;
        }
        public void SetErrToMailQueue(string fromAddress, string fromDisName, string toAddress, string toDisName, string subject, string body, string keyMan)
        {
            Mail.KEY_MAN = keyMan;
            Mail mail = new Mail();
            MailAddress to = new MailAddress(toAddress, toDisName);
            MailAddress from = new MailAddress(fromAddress, fromDisName);
            mail.AddMailQueue(from, to, false, subject, body);
        }
        public void addMsgToMailQueue()
        {

        }
    }
}
