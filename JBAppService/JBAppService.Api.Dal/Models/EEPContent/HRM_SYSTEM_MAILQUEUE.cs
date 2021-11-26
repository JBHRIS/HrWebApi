using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_MAILQUEUE
    {
        public int MAILQUEUE_ID { get; set; }
        public string MESSAGE_TYPE_CODE { get; set; }
        public string FROM_MAIL_ADDR { get; set; }
        public string FROM_NAME { get; set; }
        public string TO_MAIL_ADDR { get; set; }
        public string TO_NAME { get; set; }
        public string SUBJECT { get; set; }
        public string BODY { get; set; }
        public int? RETRY { get; set; }
        public string SUCCESS { get; set; }
        public string SUSPEND { get; set; }
        public DateTime? FREEZE_TIME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string NOTE { get; set; }
    }
}
