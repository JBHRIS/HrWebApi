using JBHRIS.Api.Dal.Mail.View;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using JBHRIS.Api.Dto.Mail;
using NLog;
using System.Linq;

namespace JBHRIS.Api.Service.Mail.View
{
    public class MailService : IMailService
    {
        private ILogger _logger;
        private IParameter_View_GetParameter _parameter_View_GetParameter;
        private IMailqueue_View_GetMailqueue _mailqueue_View_GetMailqueue;

        public MailService(
            ILogger logger,
            IParameter_View_GetParameter parameter_View_GetParameter,
            IMailqueue_View_GetMailqueue mailqueue_View_GetMailqueue)
        {
            _logger = logger;
            _parameter_View_GetParameter = parameter_View_GetParameter;
            _mailqueue_View_GetMailqueue = mailqueue_View_GetMailqueue;
        }

        public ApiResult<string> SendMailWithQueue(string toStr, string subject, string body, DateTime? FreezeDateTime = null)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                List<ParameterDto> GetParameter = _parameter_View_GetParameter.GetParameter();
                string SendSender = GetParameter.Where(p => p.Code == "JbMail.Sender").FirstOrDefault()?.Value;
                string SendName = GetParameter.Where(p => p.Code == "JbMail.sys_mail").FirstOrDefault()?.Value;
                string HostName = GetParameter.Where(p => p.Code == "JbMail.host").FirstOrDefault()?.Value;
                int Port = Convert.ToInt32(GetParameter.Where(p => p.Code == "JbMail.port").FirstOrDefault()?.Value);
                MailPriority Priority = (MailPriority)Convert.ToInt32(GetParameter.Where(p => p.Code == "JbMail.Priority").FirstOrDefault()?.Value);
                bool Enable_Test_Mode = Convert.ToBoolean(Convert.ToInt32(GetParameter.Where(p => p.Code == "JbMail.EnableTestMode").FirstOrDefault()?.Value));
                string TestAccount = GetParameter.Where(p => p.Code == "JbMail.TestAccount").FirstOrDefault()?.Value;
                bool DisableSendMail = Convert.ToBoolean(Convert.ToInt32(GetParameter.Where(p => p.Code == "JbMail.DisableSendMail").FirstOrDefault()?.Value));

                var to = new MailAddress(toStr);
                var from = new MailAddress(SendSender, SendName);
                MailMessage message = null;
                MailqueueDto mq = new MailqueueDto();

                DateTime now = DateTime.Now;
                mq.Body = body;
                mq.FromAddr = from.Address;
                mq.FromName = from.DisplayName;
                mq.Guid = Guid.NewGuid().ToString();
                mq.KeyDate = now;
                mq.KeyMan = "JB";
                mq.Retry = 0;
                mq.Subject = subject;
                mq.Success = false;
                mq.ToAddr = to.Address;
                mq.ToName = to.DisplayName;
                if (FreezeDateTime == null)
                    mq.FreezeTime = now;
                else
                    mq.FreezeTime = FreezeDateTime.Value;

                _mailqueue_View_GetMailqueue.InsertMailqueue(mq);

                SmtpClient smtpClient = new SmtpClient(HostName);

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
                //if (mq.NOTE1 != null && mq.NOTE1.Trim().Length > 0)
                //{
                //    var attachSQL = from a in db.HR_File where a.GroupID == mq.NOTE1 select a;
                //    foreach (var it in attachSQL)
                //    {
                //        MemoryStream ms = new MemoryStream(it.FileBinary.ToArray());
                //        Attachment am = new Attachment(ms, it.FileName);
                //        message.Attachments.Add(am);
                //    }
                //    if (!JBModule.Message.UI.DbContext.IsTableExists("FileStreamInfo"))
                //    {
                //        FileStreamService fsService = new FileStreamService();
                //        var files = fsService.DownloadByTicket(mq.NOTE1);
                //        foreach (var file in files)
                //        {
                //            Attachment am = new Attachment(file.FileStream, file.FileName);
                //            message.Attachments.Add(am);
                //        }
                //    }
                //}
                if (!DisableSendMail)
                {
                    //smtpClient.Send(message); //訂閱制主機目前無法主動發信
                }
                else
                {
                    apiResult.Message = "未開啟寄信功能";
                    _logger.Warn("傳送郵件到" + to.Address + "(" + to.DisplayName + ")" + (DisableSendMail ? "未實際送出" : ""), "SendMail", "Mail", mq.Id);
                }
                //mq.Success = true;//訂閱制主機目前無法主動發信
                //_mailqueue_View_GetMailqueue.UpdateMailqueue(mq);//訂閱制主機目前無法主動發信
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
                _logger.Warn(ex.ToString());

            }

            return apiResult;
        }
    }
}
