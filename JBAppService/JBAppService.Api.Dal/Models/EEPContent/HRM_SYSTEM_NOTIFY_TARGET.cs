using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_NOTIFY_TARGET
    {
        public int TARGET_ID { get; set; }
        public int NOTIFY_ID { get; set; }
        public string NOTIFY_TARGET { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string MAIL_NAME { get; set; }
        public string MAIL { get; set; }
        public string MEMO { get; set; }
    }
}
