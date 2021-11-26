using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_NOTIFY_MAIN
    {
        public int NOTIFY_ID { get; set; }
        public string NOTIFY_CODE { get; set; }
        public string NOTIFY_NAME { get; set; }
        public string IS_SCHEDULE { get; set; }
        public string IS_STOP { get; set; }
        public string MEMO { get; set; }
        public string SUBJECT { get; set; }
        public string BODY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
