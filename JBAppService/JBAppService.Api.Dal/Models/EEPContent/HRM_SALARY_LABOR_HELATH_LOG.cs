using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_LABOR_HELATH_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_FAMILY_IDNO { get; set; }
        public string EXPENSE_YYMM { get; set; }
        public decimal? INSURANCE_AMT { get; set; }
        public decimal? EXPENSE { get; set; }
        public decimal? COMPANY_BURDEN { get; set; }
        public string NOT_MODIFY { get; set; }
        public DateTime? EFFECT_DATE { get; set; }
        public decimal? DAYS { get; set; }
        public string ALLOWANCE_CODE { get; set; }
        public string INSURANCE_EXPENSE_TYPE { get; set; }
        public string INSURANCE_KIND { get; set; }
        public int? SALARY_ID { get; set; }
        public decimal? JOB_DISASTER_AMT { get; set; }
        public decimal? FUND_AMT { get; set; }
        public int INSURANCE_COMPANY_ID { get; set; }
        public string GROUP_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
