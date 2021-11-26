using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_DEPT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int DEPT_ID { get; set; }
        public string DEPT_CODE { get; set; }
        public string DEPT_ASSISTANT_CODE { get; set; }
        public string DEPT_CNAME { get; set; }
        public string DEPT_ENAME { get; set; }
        public decimal? DEPT_PERSON { get; set; }
        public string DEPT_TREE { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public int? UPPER_DEPT_ID { get; set; }
        public string DEPT_MANAGER { get; set; }
        public string ALERT_EMAIL { get; set; }
        public string ALERT_EMAIL_LIST { get; set; }
        public string ALERT_TO_MANAGER { get; set; }
        public string ALERT_TO_EMAIL { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
