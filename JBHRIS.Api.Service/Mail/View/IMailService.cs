using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Mail.View
{
    public interface IMailService
    {
        public ApiResult<string> SendMailWithQueue(string toStr, string subject, string body, DateTime? FreezeDateTime = null);
    }
}
