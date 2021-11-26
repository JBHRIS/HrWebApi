using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace JBHRIS.Api.Tools.Tool
{
    public static class SendMail
    {
        private delegate void AsyncMethodCaller(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody, out int threadId);

        /// <summary>
        /// 傳送信件射後不理
        /// </summary>
        /// <param name="sMailServerName">郵件伺服器IP或Name</param>
        /// <param name="sFrom">寄件者Mail</param>
        /// <param name="bIsUseDefaultCredentials">True = 要驗証</param>
        /// <param name="sFromID">寄件者帳號(若是需要驗証,則就需要輸入寄件者帳號)</param>
        /// <param name="sFromPW">寄件者密碼(若是需要驗証,則就需要輸入寄件者密碼)</param>
        /// <param name="sTo">收件者Mail</param>
        /// <param name="sSubject">主旨</param>
        /// <param name="sBody">內文</param>
        public static void SendThread(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody)
        {
            int threadId = 0;
            AsyncMethodCaller caller = new AsyncMethodCaller(Send);
            IAsyncResult result = caller.BeginInvoke(sMailServerName, sFrom, bIsUseDefaultCredentials, sFromID, sFromPW, sTo, sSubject, sBody, out threadId, null, null);
        }

        private static void Send(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody, out int threadId)
        {
            threadId = 0;
            Send(sMailServerName, sFrom, bIsUseDefaultCredentials, sFromID, sFromPW, sTo, sSubject, sBody);
        }

        /// <summary>
        /// 傳送信件
        /// </summary>
        /// <param name="sMailServerName">郵件伺服器IP或Name</param>
        /// <param name="sFrom">寄件者Mail</param>
        /// <param name="bIsUseDefaultCredentials">True = 要驗証</param>
        /// <param name="sFromID">寄件者帳號(若是需要驗証,則就需要輸入寄件者帳號)</param>
        /// <param name="sFromPW">寄件者密碼(若是需要驗証,則就需要輸入寄件者密碼)</param>
        /// <param name="sTo">收件者Mail</param>
        /// <param name="sSubject">主旨</param>
        /// <param name="sBody">內文</param>
        public static void Send(string sMailServerName, string sFrom, bool bIsUseDefaultCredentials, string sFromID, string sFromPW, string sTo, string sSubject, string sBody)
        {
            try
            {
                using (MailMessage message =
                    new MailMessage(sFrom, sTo, sSubject, sBody))
                {
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.High;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;

                    SmtpClient mailClient = new SmtpClient(sMailServerName);
                    mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    if (bIsUseDefaultCredentials)
                    {
                        mailClient.UseDefaultCredentials = true;
                    }


                    else
                    {
                        mailClient.UseDefaultCredentials = false;
                        mailClient.Credentials = new System.Net.NetworkCredential(sFromID, sFromPW);
                    }

                    mailClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
            }
        }
    }
}
