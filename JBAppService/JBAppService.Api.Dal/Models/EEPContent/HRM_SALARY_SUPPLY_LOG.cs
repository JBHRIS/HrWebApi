using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_SUPPLY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_SEQ { get; set; }
        public int SALARY_ID { get; set; }
        public DateTime PAYMENT_DATE { get; set; }
        public string TAX_FORMAT { get; set; }
        public decimal PAYMENT_AMT { get; set; }
        public decimal SUPPLY_AMT { get; set; }
        public decimal EMPLOYEE_HEALTH_AMT { get; set; }
        public DateTime BEGIN_DATE { get; set; }
        public DateTime END_DATE { get; set; }
        public decimal TOTAL_AMT { get; set; }
        public int INSURANCE_COMPANY_ID { get; set; }
        public string GROUP_ID { get; set; }
        public string NOT_MODIFY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
