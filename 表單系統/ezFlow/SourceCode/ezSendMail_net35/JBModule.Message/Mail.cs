using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
/// <summary>
/// JbMail 的摘要描述
/// </summary>
namespace JBModule.Message
{
    public class Mail
    {
        public Mail()
        {

        }
        public delegate void MailExceptionHandler(Object sender , Exception e);
        public static event MailExceptionHandler MailException;

        public static string HostName
        {
            get
            {
                string host = ConfigSetting.AppSettingValue("JbMail.host");
                return host;
            }
        }
        public static bool IsNeedCredentials
        {
            get
            {
                bool isCred = ConfigSetting.AppSettingValue("JbMail.IsNeedCredentials") == "1";
                return isCred;
            }
        }
        public static string SystemMailAccount
        {
            get
            {
                string account = ConfigSetting.AppSettingValue("JbMail.sys_mail");
                return account;
            }
        }
        public static string Password
        {
            get
            {
                string pwd = ConfigSetting.AppSettingValue("JbMail.sys_pwd");
                return pwd;
            }
        }
        public static int Port
        {
            get
            {
                int port = Convert.ToInt32(ConfigSetting.AppSettingValue("JbMail.port"));
                return port;
            }
        }
        public static bool Enable_Test_Mode
        {
            get
            {
                try
                {
                    bool TestMode = ConfigSetting.AppSettingValue("JbMail.EnableTestMode") == "1";
                    return TestMode;
                }
                catch
                {
                    return false;//預設不啟用測試模式
                }
            }
        }
        public static string TestAccount
        {
            get
            {
                string TestAcc = ConfigSetting.AppSettingValue("JbMail.TestAccount");
                return TestAcc;
            }
        }
        public static bool DisableSendMail
        {
            get
            {
                try
                {
                    bool disable = ConfigSetting.AppSettingValue("JbMail.DisableSendMail") == "1";
                    return disable;
                }
                catch
                {
                    return false;//如果找不到或是錯誤，顯示false，以確保信件可以寄出
                }
            }
        }
        public static MailPriority Priority
        {
            get
            {
                try
                {
                    int priority = Convert.ToInt32(ConfigSetting.AppSettingValue("JbMail.Priority"));
                    return (MailPriority) priority;
                }
                catch
                {
                    return MailPriority.Normal;//如果找不到或是錯誤，顯示false，以確保信件可以寄出
                }
            }
        }
        public static void SendMail(MailAddress from , MailAddress to , string subject , string body)
        {
            MailMessage message = null;

            try
            {
                SmtpClient smtpClient = new SmtpClient(HostName);

                if ( IsNeedCredentials )
                    smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount , Password);

                smtpClient.Port = Port;

                if ( Enable_Test_Mode )
                    to = new MailAddress(TestAccount , to.Address);
                //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                message = new MailMessage(from , to);

                message.Subject = subject;

                message.IsBodyHtml = true;

                message.Priority = Priority;

                message.Body = body;

                message.BodyEncoding = System.Text.Encoding.Default;

                message.SubjectEncoding = System.Text.Encoding.Default;

                if ( !DisableSendMail )
                    smtpClient.Send(message);
                TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
            }
            catch ( Exception ex )
            {
                if ( MailException != null )
                    MailException.Invoke(message , ex);
                else
                    throw ex;
            }
        }
        public static void SendMail(string from_mail , string to_mail , string subject , string body)
        {
            try
            {
                MailAddress from = new MailAddress(from_mail);
                MailAddress to = new MailAddress(to_mail);
                SendMail(from , to , subject , body);
            }
            catch ( Exception ex )
            {
                MailException.Invoke(null , ex);
            }
        }

    }
}