using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_HEALTH_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? EMPLOYEE_HEALTH_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? INSURANCE_COMPANY_ID { get; set; }
        public string EMPLOYEE_INSURANCE_TYPE { get; set; }
        public string HEALTH_ALLOWANCE_CODE { get; set; }
        public int? EMPLOYEE_HEALTH_AMT { get; set; }
        public string HEALTH_LEAVE_CAUSE_CODE { get; set; }
        public string EMPLOYEE_HEALTH_MEMO { get; set; }
        public string REPORT_DONE { get; set; }
        public DateTime? REPORT_DONE_DATE { get; set; }
        public DateTime? HEALTH_EFFECTIVE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
