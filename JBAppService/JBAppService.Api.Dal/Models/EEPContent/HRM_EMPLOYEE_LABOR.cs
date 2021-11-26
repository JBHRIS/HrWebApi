using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_LABOR
    {
        public int EMPLOYEE_LABOR_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? INSURANCE_COMPANY_ID { get; set; }
        public string EMPLOYEE_INSURANCE_TYPE { get; set; }
        public string LABOR_ALLOWANCE_CODE { get; set; }
        public string LABOR_LEAVE_CAUSE_CODE { get; set; }
        public string LABOR_SPECIAL_TYPE { get; set; }
        public string LABOR_LOW_TYPE { get; set; }
        public int? EMPLOYEE_LABOR_AMT { get; set; }
        public string EMPLOYEE_LABOR_MEMO { get; set; }
        public string REPORT_DONE { get; set; }
        public DateTime? REPORT_DONE_DATE { get; set; }
        public DateTime? LABOR_EFFECTIVE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
