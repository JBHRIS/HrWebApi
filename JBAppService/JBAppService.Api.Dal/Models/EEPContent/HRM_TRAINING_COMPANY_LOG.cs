using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_TRAINING_COMPANY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int TRAINING_COMPANY_ID { get; set; }
        public string TRAINING_COMPANY_CODE { get; set; }
        public string TRAINING_COMPANY_CNAME { get; set; }
        public string TRAINING_COMPANY_ENAME { get; set; }
        public string TRAINING_COMPANY_TEL { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
