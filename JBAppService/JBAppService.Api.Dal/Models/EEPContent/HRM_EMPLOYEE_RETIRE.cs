using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_RETIRE
    {
        public int EMPLOYEE_RETIRE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? INSURANCE_COMPANY_ID { get; set; }
        public string EMPLOYEE_INSURANCE_TYPE { get; set; }
        public string RETIRE_RATE_TYPE_ID { get; set; }
        public string RETIRE_LEAVE_CAUSE_CODE { get; set; }
        public decimal? RETIRE_COMPANY_RATE { get; set; }
        public decimal? RETIRE_SELF_RATE { get; set; }
        public int? EMPLOYEE_RETIRE_AMT { get; set; }
        public string EMPLOYEE_RETIRE_MEMO { get; set; }
        public string REPORT_DONE { get; set; }
        public DateTime? REPORT_DONE_DATE { get; set; }
        public DateTime? RETIRE_EFFECTIVE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
