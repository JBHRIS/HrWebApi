using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.IO;
using JBModule.Message.Service;

/// <summary>
/// JbMail 的摘要描述
/// </summary>
namespace JBModule.Message
{
    public class Mail
    {
        public Mail()
        {
            sGuid = Guid.NewGuid().ToString();
            //refreshData();
        }

        public string sGuid = "";
        public static string KEY_MAN = "JB";
        public static int order_in = 1; // 尋找資料順序
        public delegate void MailExceptionHandler(Object sender, Exception e);
        public static event MailExceptionHandler MailException;
        static string[] CredentialCacheType = new string[] { "gssapi", "ntlm", "WDigest", "login" };
        static List<PARAMETER> parms = new List<PARAMETER>();

        static Mail()
        {
            refreshData();
        }

        private static string _hostname = string.Empty;
        public static string HostName
        {
            get
            {
                return _hostname;
            }
            private set
            {
                _hostname = UseDB ? GetParameterValue("JbMail.host") : ConfigSetting.AppSettingValue("JbMail.host");
            }
        }

        private static string _sendname = string.Empty;
        // 傳送者名稱
        public static string SendName
        {
            get
            {
                return _sendname;

            }
            private set
            {
                _sendname = UseDB ? GetParameterValue("JbMail.SenderName") : "jbjob";
            }
        }

        private static string _sendsender = string.Empty;
        public static string SendSender
        {
            get
            {
                return _sendsender;
            }
            private set
            {
                _sendsender = UseDB ? GetParameterValue("JbMail.Sender") : "eflow@jbjob.com.tw";
            }
        }

        private static bool _isneedcredentials = false;
        public static bool IsNeedCredentials
        {
            get
            {
                return _isneedcredentials;
            }
            private set
            {
                _isneedcredentials = UseDB ? GetParameterValue("JbMail.IsNeedCredentials") == "1" : ConfigSetting.AppSettingValue("JbMail.IsNeedCredentials") == "1";
            }
        }

        private static bool _usedb = true;
        public static bool UseDB
        {
            get
            {
                return _usedb;
            }
            private set
            {
                _usedb = ConfigSetting.AppSettingValue("JbMail.DataType") == "1";
            }
        }

        private static string _credentialstype = string.Empty;
        public static string CredentialsType
        {
            get
            {
                return _credentialstype;

            }
            private set
            {
                try
                {
                    _credentialstype = UseDB ? CredentialCacheType[Convert.ToInt32(GetParameterValue("JbMail.CredentialsType"))] : CredentialCacheType[Convert.ToInt32(ConfigSetting.AppSettingValue("JbMail.CredentialsType"))];
                }
                catch
                {
                    _credentialstype = CredentialCacheType[0];
                }
            }
        }

        private static string _systemmailaccount = string.Empty;
        public static string SystemMailAccount
        {
            get
            {
                return _systemmailaccount;
            }
            private set
            {
                _systemmailaccount = UseDB ? GetParameterValue("JbMail.sys_mail") : ConfigSetting.AppSettingValue("JbMail.sys_mail");
            }
        }

        private static string _password = string.Empty;
        public static string Password
        {
            get
            {
                return _password;
            }
            private set
            {
                _password = UseDB ? GetParameterValue("JbMail.sys_pwd") : ConfigSetting.AppSettingValue("JbMail.sys_pwd");
            }
        }

        private static int _port = 25;
        public static int Port
        {
            get
            {
                return _port;
            }
            private set
            {
                try
                {
                    _port = UseDB ? Convert.ToInt32(GetParameterValue("JbMail.port")) : Convert.ToInt32(ConfigSetting.AppSettingValue("JbMail.port"));
                }
                catch
                {
                    _port = 25;
                }
            }
        }
        private static bool _ssl = false;
        public static bool SSL
        {
            get
            {
                return _ssl;
            }
            private set
            {
                try
                {
                    _ssl = UseDB ? GetParameterValue("JbMail.SSL") == "1" : ConfigSetting.AppSettingValue("JbMail.SSL").ToString() == "1";
                }
                catch
                {
                    _ssl = false;
                }
            }
        }
        private static bool _enable_test_mode = false;
        public static bool Enable_Test_Mode
        {
            get
            {
                return _enable_test_mode;
            }
            private set
            {
                try
                {
                    _enable_test_mode = UseDB ? GetParameterValue("JbMail.EnableTestMode") == "1" : ConfigSetting.AppSettingValue("JbMail.EnableTestMode") == "1";
                }
                catch
                {
                    _enable_test_mode = false;//預設不啟用測試模式
                }
            }
        }

        private static string _testaccount = string.Empty;
        public static string TestAccount
        {
            get
            {
                return _testaccount;
            }
            private set
            {
                _testaccount = UseDB ? GetParameterValue("JbMail.TestAccount") : ConfigSetting.AppSettingValue("JbMail.TestAccount");
            }
        }

        private static bool _disablesendmail = false;
        public static bool DisableSendMail
        {
            get
            {
                return _disablesendmail;
            }
            private set
            {
                try
                {
                    _disablesendmail = UseDB ? GetParameterValue("JbMail.DisableSendMail") == "1" : ConfigSetting.AppSettingValue("JbMail.DisableSendMail") == "1";
                }

                catch
                {
                    _disablesendmail = false;
                }
            }
        }

        public static List<string> GetReceiverList()
        {
            var sql = from a in Parameters where a.CODE.Contains("JbMail.Receiver") && a.VALUE != null && a.VALUE.Trim().Length > 0 select a.VALUE;
            return sql.ToList();
        }

        private static MailPriority _priority = MailPriority.Normal;
        public static MailPriority Priority
        {
            get
            {
                return _priority = MailPriority.Normal;
            }
            private set
            {
                try
                {
                    _priority = UseDB ? (MailPriority)Convert.ToInt32(GetParameterValue("JbMail.Priority")) : (MailPriority)Convert.ToInt32(ConfigSetting.AppSettingValue("JbMail.Priority"));
                }
                catch
                {
                    _priority = MailPriority.Normal;//如果找不到或是錯誤，顯示false，以確保信件可以寄出
                }
            }
        }

        public static string GetMailSetting(string ConfigName)
        {
            try
            {
                string result = "";
                if (UseDB) result = GetParameterValue(ConfigName);
                result = ConfigSetting.AppSettingValue(ConfigName);
                return result;
            }
            catch
            {
                return "";
            }
        }
        public static List<PARAMETER> Parameters
        {
            get
            {
                if (!parms.Any())
                {
                    RefreshParm();
                }
                return parms;
            }
        }
        public static void RefreshParm(int? order = null)
        {
            DBDataContext db = new DBDataContext();
            var query = from a in db.PARAMETER_TREE where a.CODE == "MailSettings" select a;
            if (query.Any())
            {
                int gid;
                if (order.HasValue)
                {
                    gid = order.Value;
                    parms = (from a in db.PARAMETER where a.PARMGROUP_AUTO == gid select a).ToList();
                    refreshData(order.Value);
                    return;
                }
                else
                {
                    gid = query.First().AUTO;
                }
                parms = (from a in db.PARAMETER where a.PARMGROUP_AUTO == gid select a).ToList();
            }
        }

        //public static string GetParameterValue(string Code)
        //{
        //    var query = from a in Parameters where a.CODE == Code select a;
        //    if (query.Any()) return query.First().VALUE;
        //    return "";
        //}

        public static string GetParameterValue(string Code)
        {
            var query = (from a in Parameters where a.CODE == Code select a).FirstOrDefault();

            if (query != null)
            {
                return query.VALUE;
            }
            else
            {
                return string.Empty;
            }
        }
        public static List<string> GetParameterValueList(string Code)
        {
            var query = (from a in Parameters where a.CODE.Contains(Code) select a);

            return query.Select(p => p.VALUE).ToList();
        }

        private static bool refreshData(int order = 1)
        {
            order_in = order;

            HostName = string.Empty;
            CredentialsType = string.Empty;
            Delay = 0;
            DisableSendMail = false;
            Enable_Test_Mode = false;
            HostName = string.Empty;
            IsNeedCredentials = false;
            MaxRetry = 0;
            Password = string.Empty;
            Port = 0;
            Priority = MailPriority.Normal;
            SendName = string.Empty;
            SendSender = string.Empty;
            SystemMailAccount = string.Empty;
            TestAccount = string.Empty;
            UseDB = true;
            SSL = false;
            return true;
        }


        public void AddMailQueue(string toStr, string subject, string body)
        {
            AddMailQueue(toStr, subject, body, string.Empty);
        }
        // 自動抓取parameter table 參數
        public void AddMailQueue(string toStr, string subject, string body, string AttachmentID = "", DateTime? FreezeDateTime = null)
        {
            try
            {
                var to = new MailAddress(toStr);
                var from = new MailAddress(SendSender, SendName);

                DBDataContext db = new DBDataContext();
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                mq.NOTE1 = AttachmentID;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", -1);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }
        public void AddMailQueueWithFileService(string toStr, string subject, string body, List<Attachment> AttachmentList, DateTime? FreezeDateTime = null)
        {
            try
            {
                var to = new MailAddress(toStr);
                var from = new MailAddress(SendSender, SendName);

                DBDataContext db = new DBDataContext();
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                mq.NOTE1 = Guid.NewGuid().ToString();
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                db.MAILQUEUE.InsertOnSubmit(mq);
                foreach (var attachment in AttachmentList)
                {
                    JBHRIS.BLL.Service.FileStreamService fss = new FileStreamService(db.Connection);
                    JBHRIS.BLL.Dto.FileStreamInfoDto fsDto = new JBHRIS.BLL.Dto.FileStreamInfoDto();
                    fsDto.FileName = attachment.Name;
                    fsDto.FileSize = attachment.ContentStream.Length;
                    fsDto.FileStream = attachment.ContentStream;
                    fsDto.FileTicket = mq.NOTE1;
                    fsDto.ExtensionName = attachment.ContentType.Name;
                    fsDto.FullName = attachment.Name;
                    fsDto.FileID = -1;
                    fsDto.CreateMan = Mail.KEY_MAN;
                    fsDto.CreateTime = DateTime.Now;
                    fss.Upload(fsDto);
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", -1);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }

        public void AddMailQueue(MailAddress from, MailAddress to, string subject, string body)
        {
            AddMailQueue(from, to, subject, body, string.Empty);
        }

        public void AddMailQueue(MailAddress from, MailAddress to, string subject, string body, string AttachmentID = "", DateTime? FreezeDateTime = null)
        {
            try
            {
                DBDataContext db = new DBDataContext();
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                mq.NOTE1 = AttachmentID;
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", -1);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }
        public void AddMailQueue(MailAddress from, MailAddress to, bool isSuccess, string subject, string body, DateTime? FreezeDateTime = null)
        {
            AddMailQueue(from, to, isSuccess, subject, body, string.Empty, FreezeDateTime);
        }
        public void AddMailQueue(MailAddress from, MailAddress to, bool isSuccess, string subject, string body, string AttachmentID = "", DateTime? FreezeDateTime = null)
        {
            try
            {
                DBDataContext db = new DBDataContext();
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = isSuccess;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                mq.NOTE1 = AttachmentID;
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", -1);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }
        public void AddMailQueue(MailAddress from, MailAddress to, string subject, string body, DateTime StartTime, string AttachmentID = "", DateTime? FreezeDateTime = null)
        {
            try
            {
                DBDataContext db = new DBDataContext();
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                mq.NOTE1 = AttachmentID;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = StartTime;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", -1);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }
        public void SendMailWithQueue(string toStr, string subject, string body, DateTime? FreezeDateTime = null)
        {
            int id = -1;
            try
            {
                var to = new MailAddress(toStr);
                var from = new MailAddress(SendSender, SendName);
                DBDataContext db = new DBDataContext();
                MailMessage message = null;
                MAILQUEUE mq = new MAILQUEUE();

                mq.BODY = body;
                //mq.FROM_ADDR = from.Address;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
                id = mq.ID;
                SmtpClient smtpClient = new SmtpClient(HostName);

                if (IsNeedCredentials)
                {
                    //smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount, Password);
                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(HostName, Port, CredentialsType, new NetworkCredential(SystemMailAccount, Password));
                    smtpClient.Credentials = myCache;
                }

                smtpClient.Port = Port;

                if (Enable_Test_Mode)
                    to = new MailAddress(TestAccount, to.Address);
                //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                message = new MailMessage(from, to);

                message.Subject = subject;

                message.IsBodyHtml = true;

                message.Priority = Priority;

                message.Body = body;

                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.SubjectEncoding = System.Text.Encoding.UTF8;
                if (mq.NOTE1 != null && mq.NOTE1.Trim().Length > 0)
                {
                    var attachSQL = from a in db.HR_File where a.GroupID == mq.NOTE1 select a;
                    foreach (var it in attachSQL)
                    {
                        MemoryStream ms = new MemoryStream(it.FileBinary.ToArray());
                        Attachment am = new Attachment(ms, it.FileName);
                        message.Attachments.Add(am);
                    }
                    if (!JBModule.Message.UI.DbContext.IsTableExists("FileStreamInfo"))
                    {
                        FileStreamService fsService = new FileStreamService();
                        var files = fsService.DownloadByTicket(mq.NOTE1);
                        foreach (var file in files)
                        {
                            Attachment am = new Attachment(file.FileStream, file.FileName);
                            message.Attachments.Add(am);
                        }
                    }
                }
                if (!DisableSendMail)
                    smtpClient.Send(message);
                mq.SUCCESS = true;
                db.SubmitChanges();
                TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
                DbLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""), "SendMail", "Mail", mq.ID);
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", id);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }
        public void SendMailWithQueue(MailAddress from, MailAddress to, string subject, string body, string AttachmentID = "", DateTime? FreezeDateTime = null)
        {
            int id = -1;
            try
            {
                DBDataContext db = new DBDataContext();
                MailMessage message = null;
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                mq.NOTE1 = AttachmentID;
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
                id = mq.ID;
                SmtpClient smtpClient = new SmtpClient(HostName);

                if (IsNeedCredentials)
                {
                    //smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount, Password);
                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(HostName, Port, CredentialsType, new NetworkCredential(SystemMailAccount, Password));
                    smtpClient.Credentials = myCache;

                }
                smtpClient.EnableSsl = Mail.SSL;
                smtpClient.Port = Port;

                if (Enable_Test_Mode)
                    to = new MailAddress(TestAccount, to.Address);
                //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                message = new MailMessage(from, to);

                message.Subject = subject;

                message.IsBodyHtml = true;

                message.Priority = Priority;

                message.Body = body;

                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.SubjectEncoding = System.Text.Encoding.UTF8;
                if (mq.NOTE1 != null && mq.NOTE1.Trim().Length > 0)
                {
                    var attachSQL = from a in db.HR_File where a.GroupID == mq.NOTE1 select a;
                    foreach (var it in attachSQL)
                    {
                        MemoryStream ms = new MemoryStream(it.FileBinary.ToArray());
                        Attachment am = new Attachment(ms, it.FileName);
                        message.Attachments.Add(am);
                    }
                }
                if (!DisableSendMail)
                    smtpClient.Send(message);
                mq.SUCCESS = true;
                db.SubmitChanges();
                TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
                DbLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""), "SendMail", "Mail", mq.ID);
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", id);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
        }
        public int SendMailWithQueue(MailAddress from, MailAddress to, string subject, string body, List<Attachment> AttachmentList, DateTime? FreezeDateTime = null)
        {
            int id = -1;
            try
            {
                DBDataContext db = new DBDataContext();
                MailMessage message = null;
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                mq.NOTE1 = "";
                db.MAILQUEUE.InsertOnSubmit(mq);
                db.SubmitChanges();
                id = mq.ID;
                SmtpClient smtpClient = new SmtpClient(HostName);

                if (IsNeedCredentials)
                {
                    //smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount, Password);

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(HostName, Port, CredentialsType, new NetworkCredential(SystemMailAccount, Password));
                    smtpClient.Credentials = myCache;
                }
                smtpClient.EnableSsl = Mail.SSL;
                smtpClient.Port = Port;
                if (Enable_Test_Mode)
                    to = new MailAddress(TestAccount, to.Address);
                //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                message = new MailMessage(from, to);

                message.Subject = subject;

                message.IsBodyHtml = true;

                message.Priority = Priority;

                message.Body = body;

                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.SubjectEncoding = System.Text.Encoding.UTF8;
                foreach (var it in AttachmentList)
                {
                    message.Attachments.Add(it);
                }
                if (!DisableSendMail)
                    smtpClient.Send(message);
                mq.SUCCESS = true;
                db.SubmitChanges();
                TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
                DbLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""), "SendMail", "Mail", mq.ID);
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", id);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
            return id;
        }
        public int SendMailWithQueueAndFileService(MailAddress from, MailAddress to, string subject, string body, List<Attachment> AttachmentList, DateTime? FreezeDateTime = null)
        {
            int id = -1;
            try
            {
                DBDataContext db = new DBDataContext();
                MailMessage message = null;
                MAILQUEUE mq = new MAILQUEUE();
                mq.BODY = body;
                mq.FROM_ADDR = from.Address;
                mq.FROM_NAME = from.DisplayName;
                mq.GUID = sGuid;
                mq.KEY_DATE = DateTime.Now;
                mq.KEY_MAN = KEY_MAN;
                mq.RETRY = 0;
                mq.SUBJECT = subject;
                mq.SUCCESS = false;
                mq.TO_ADDR = to.Address;
                mq.TO_NAME = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FREEZE_TIME = DateTime.Now;
                else
                    mq.FREEZE_TIME = FreezeDateTime.Value;
                mq.NOTE1 = Guid.NewGuid().ToString();
                db.MAILQUEUE.InsertOnSubmit(mq);
                foreach (var attachment in AttachmentList)
                {

                    JBHRIS.BLL.Service.FileStreamService fss = new FileStreamService();

                    JBHRIS.BLL.Dto.FileStreamInfoDto fsDto = new JBHRIS.BLL.Dto.FileStreamInfoDto();
                    fsDto.FileName = attachment.Name;
                    fsDto.FileSize = attachment.ContentStream.Length;
                    fsDto.FileStream = attachment.ContentStream;
                    fsDto.FileTicket = mq.NOTE1;
                    fsDto.ExtensionName = attachment.ContentType.Name;
                    fsDto.FullName = attachment.Name;
                    fsDto.FileID = -1;
                    fsDto.CreateMan = Mail.KEY_MAN;
                    fsDto.CreateTime = DateTime.Now;
                    fss.Upload(fsDto);

                }
                db.SubmitChanges();
                if (mq.FREEZE_TIME <= DateTime.Now)
                {
                    id = mq.ID;
                    SmtpClient smtpClient = new SmtpClient(HostName);

                    if (IsNeedCredentials)
                    {
                        //smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount, Password);

                        CredentialCache myCache = new CredentialCache();
                        myCache.Add(HostName, Port, CredentialsType, new NetworkCredential(SystemMailAccount, Password));
                        smtpClient.Credentials = myCache;
                    }
                    smtpClient.EnableSsl = Mail.SSL;
                    smtpClient.Port = Port;
                    if (Enable_Test_Mode)
                        to = new MailAddress(TestAccount, to.Address);
                    //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                    message = new MailMessage(from, to);

                    message.Subject = subject;

                    message.IsBodyHtml = true;

                    message.Priority = Priority;

                    message.Body = body;

                    message.BodyEncoding = System.Text.Encoding.UTF8;

                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    foreach (var it in AttachmentList)
                    {
                        message.Attachments.Add(it);
                    }
                    if (!DisableSendMail)
                        smtpClient.Send(message);
                    mq.SUCCESS = true;
                    db.SubmitChanges();
                    TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
                    DbLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""), "SendMail", "Mail", mq.ID);
                }
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", id);
                //if (MailException != null)
                //    MailException.Invoke(message, ex);
                //else
                //    throw ex;
            }
            return id;
        }
        public void SendMailWithQueue(string from, string to, string subject, string body, DateTime? FreezeDateTime = null)
        {
            try
            {
                SendMailWithQueue(new MailAddress(from), new MailAddress(to), subject, body, "", FreezeDateTime);
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
                DbLog.WriteLog(ex, "Mail", -1);
            }
        }
        public static void SendMail(MailAddress from, MailAddress to, string subject, string body, List<Attachment> AttachmentList)
        {
            MailMessage message = null;
            DBDataContext db = new DBDataContext();
            try
            {
                SmtpClient smtpClient = new SmtpClient(HostName);

                if (IsNeedCredentials)
                {
                    //smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount, Password);

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(HostName, Port, CredentialsType, new NetworkCredential(SystemMailAccount, Password));
                    smtpClient.Credentials = myCache;
                }
                smtpClient.EnableSsl = Mail.SSL;
                smtpClient.Port = Port;

                if (Enable_Test_Mode)
                    to = new MailAddress(TestAccount, to.Address);
                //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                message = new MailMessage(from, to);

                message.Subject = subject;

                message.IsBodyHtml = true;

                message.Priority = Priority;

                message.Body = body;

                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.SubjectEncoding = System.Text.Encoding.UTF8;
                foreach (var it in AttachmentList)
                {
                    message.Attachments.Add(it);
                }
                if (!DisableSendMail)
                    smtpClient.Send(message);
                TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
            }
            catch (Exception ex)
            {
                if (MailException != null)
                    MailException.Invoke(message, ex);
                else
                    throw ex;
            }
        }
        public static void SendMail(MailAddress from, MailAddress to, string subject, string body, string AttachmentID = "")
        {
            MailMessage message = null;
            DBDataContext db = new DBDataContext();
            try
            {
                SmtpClient smtpClient = new SmtpClient(HostName);

                if (IsNeedCredentials)
                {
                    //smtpClient.Credentials = new System.Net.NetworkCredential(SystemMailAccount, Password);

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(HostName, Port, CredentialsType, new NetworkCredential(SystemMailAccount, Password));
                    smtpClient.Credentials = myCache;
                }
                smtpClient.EnableSsl = Mail.SSL;
                smtpClient.Port = Port;

                if (Enable_Test_Mode)
                    to = new MailAddress(TestAccount, to.Address);
                //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號

                message = new MailMessage(from, to);

                message.Subject = subject;

                message.IsBodyHtml = true;

                message.Priority = Priority;

                message.Body = body;

                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.SubjectEncoding = System.Text.Encoding.UTF8;
                if (AttachmentID.Trim().Length > 0)
                {
                    var attachSQL = from a in db.HR_File where a.GroupID == AttachmentID select a;
                    foreach (var it in attachSQL)
                    {
                        MemoryStream ms = new MemoryStream(it.FileBinary.ToArray());
                        Attachment am = new Attachment(ms, it.FileName);
                        message.Attachments.Add(am);
                    }
                    if (JBModule.Message.UI.DbContext.IsTableExists("FileStreamInfo"))
                    {
                        FileStreamService fsService = new FileStreamService();
                        var files = fsService.DownloadByTicket(AttachmentID);
                        foreach (var file in files)
                        {
                            Attachment am = new Attachment(file.FileStream, file.FileName);
                            message.Attachments.Add(am);
                        }
                    }
                }
                if (!DisableSendMail)
                    smtpClient.Send(message);
                TextLog.WriteLog("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""));
            }
            catch (Exception ex)
            {
                if (MailException != null)
                    MailException.Invoke(message, ex);
                else
                    throw ex;
            }
        }
        public static void SendMail(string from_mail, string to_mail, string subject, string body, string AttachmentID = "")
        {
            try
            {
                MailAddress from = new MailAddress(from_mail);
                MailAddress to = new MailAddress(to_mail);
                SendMail(from, to, subject, body, AttachmentID);
            }
            catch (Exception ex)
            {
                if (MailException != null)
                    MailException.Invoke(null, ex);
                else throw ex;
            }
        }

        private static int _maxretry = 0;
        public static int MaxRetry
        {
            get
            {
                return _maxretry;
            }
            private set
            {
                _maxretry = Convert.ToInt32(GetParameterValue("JbMail.MaxRetry"));
            }
        }

        private static int _delay = 0;
        public static int Delay
        {
            get
            {
                return _delay;
            }
            private set
            {
                _delay = Convert.ToInt32(GetParameterValue("JbMail.Delay"));
            }
        }
        public static void CheckQueue()
        {
            DbLog.key_man = KEY_MAN;
            DBDataContext db = new DBDataContext();
            var sql = from a in db.MAILQUEUE where !a.SUCCESS && a.RETRY < MaxRetry && !a.SUSPEND && a.FREEZE_TIME < DateTime.Now select a;
            foreach (var itm in sql)
            {
                try
                {
                    itm.RETRY = itm.RETRY + 1;
                    SendMail(itm.FROM_ADDR, itm.TO_ADDR, itm.SUBJECT, itm.BODY, itm.NOTE1 != null ? itm.NOTE1 : "");
                    itm.SUCCESS = true;
                    db.SubmitChanges();
                    DbLog.WriteLog("發信完成", "成功", "Mail", itm.ID);
                }
                catch (Exception ex)
                {
                    itm.FREEZE_TIME = DateTime.Now.AddMinutes(Convert.ToDouble(Delay));
                    DbLog.WriteLog(ex, "Mail", itm.ID);
                }
            }

        }
        public static void CheckQueue(DateTime DateBegin, DateTime DateEnd)
        {
            try
            {
                TextLog.WriteLog("檢查未發送信件.....");
                DbLog.key_man = KEY_MAN;
                DBDataContext db = new DBDataContext();
                var sql = from a in db.MAILQUEUE where !a.SUCCESS && a.RETRY < MaxRetry && !a.SUSPEND && a.FREEZE_TIME >= DateBegin && a.FREEZE_TIME <= DateEnd select a;
                TextLog.WriteLog("讀取信件清單完成，共" + sql.Count() + "筆");
                foreach (var itm in sql)
                {
                    try
                    {
                        itm.RETRY = itm.RETRY + 1;
                        SendMail(itm.FROM_ADDR, itm.TO_ADDR, itm.SUBJECT, itm.BODY, itm.NOTE1 != null ? itm.NOTE1 : "");
                        itm.SUCCESS = true;
                        db.SubmitChanges();
                        DbLog.WriteLog("發信完成", "成功", "Mail", itm.ID);
                    }
                    catch (Exception ex)
                    {
                        itm.FREEZE_TIME = DateTime.Now.AddMinutes(Convert.ToDouble(Delay));
                        DbLog.WriteLog(ex, "Mail", itm.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex);
            }

        }
        public static int CheckQueue(int ID)
        {
            DbLog.key_man = KEY_MAN;
            DBDataContext db = new DBDataContext();
            int err = 0;
            var sql = from a in db.MAILQUEUE where a.ID == ID select a;
            foreach (var itm in sql)
            {
                try
                {
                    itm.RETRY = itm.RETRY + 1;
                    SendMail(itm.FROM_ADDR, itm.TO_ADDR, itm.SUBJECT, itm.BODY, itm.NOTE1 != null ? itm.NOTE1 : "");
                    itm.SUCCESS = true;
                    DbLog.WriteLog("發信完成", "成功", "Mail", itm.ID);
                }
                catch (Exception ex)
                {
                    err++;
                    itm.FREEZE_TIME = DateTime.Now.AddMinutes(30);
                    DbLog.WriteLog(ex, "Mail", itm.ID);
                }
            }
            db.SubmitChanges();
            return err;
        }
        public static string ConvertDataTableToHtml(DataTable dt)
        {

            int i = 0;
            string body = "<table  cellspacing=\"0\" cellpadding=\"3\" rules=\"all\" bordercolor=\"Black\" border=\"1\"  style=\"background-color:#F4FFF4;border-color:Black;font-family:Verdana;font-size:10pt;border-collapse:collapse;\">";
            foreach (DataRow r in dt.Rows)
            {
                if (i == 0)
                {
                    body += "<tr>";

                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc.ColumnName.ToString() == "出勤日期" || dc.ColumnName.ToString() == "員工姓名")
                            body += "<td  width=\"70px\">" + dc.ColumnName + "</td>";
                        else
                            body += "<td>" + dc.ColumnName + "</td>";
                        //body += "<td>" + dc.ColumnName + "</td>";
                    }

                    body += "</tr>";
                }

                body += "<tr>";
                foreach (DataColumn dc in dt.Columns)
                    body += "<td> " + r[dc].ToString().Trim() + "  &nbsp; </td>";

                body += "</tr>";
                i++;
            }
            body += "</table>";
            return body;
        }
    }
}