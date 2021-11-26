using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_MAILQUEUE_LOG
    {
        public int MAILQUEUE_LOG_ID { get; set; }
        public int? MAILQUEUE_ID { get; set; }
        public string ERROR_CODE { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public string TO_MAIL_ADDR { get; set; }
        public string IS_SUCCESS { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
    }
}
