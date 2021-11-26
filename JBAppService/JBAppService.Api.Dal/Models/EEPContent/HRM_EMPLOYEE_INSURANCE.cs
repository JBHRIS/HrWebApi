using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_INSURANCE
    {
        public int EMPLOYEE_INSURANCE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string INSURANCE_TYPE { get; set; }
        public int? LABOR_INSURANCE_COMPANY_ID { get; set; }
        public string LABOR_ALLOWANCE_CODE { get; set; }
        public string LABOR_LEAVE_CAUSE_CODE { get; set; }
        public string LABOR_SPECIAL_TYPE { get; set; }
        public string LABOR_LOW_TYPE { get; set; }
        public DateTime? LABOR_EFFECTIVE_DATE { get; set; }
        public int? LABOR_AMT { get; set; }
        public string LABOR_MEMO { get; set; }
        public int? HEALTH_INSURANCE_COMPANY_ID { get; set; }
        public string HEALTH_ALLOWANCE_CODE { get; set; }
        public string HEALTH_LEAVE_CAUSE_CODE { get; set; }
        public DateTime? HEALTH_EFFECTIVE_DATE { get; set; }
        public int? HEALTH_AMT { get; set; }
        public string HEALTH_MEMO { get; set; }
        public int? RETIRE_INSURANCE_COMPANY_ID { get; set; }
        public string RETIRE_LEAVE_CAUSE_CODE { get; set; }
        public string RETIRE_RATE_TYPE_ID { get; set; }
        public decimal? RETIRE_COMPANY_RATE { get; set; }
        public decimal? RETIRE_SELF_RATE { get; set; }
        public DateTime? RETIRE_EFFECTIVE_DATE { get; set; }
        public int? RETIRE_AMT { get; set; }
        public string RETIRE_MEMO { get; set; }
        public DateTime? RETIREMENT_EFFECT_DATE { get; set; }
        public string RETIREMENT_RETIRED_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
