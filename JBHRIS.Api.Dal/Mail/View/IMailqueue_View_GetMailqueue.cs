using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Mail.View
{
    public interface IMailqueue_View_GetMailqueue
    {
        public ApiResult<string> InsertMailqueue(MailqueueDto mailqueueDto);
        public ApiResult<string> UpdateMailqueue(MailqueueDto mailqueueDto);
    }
}
