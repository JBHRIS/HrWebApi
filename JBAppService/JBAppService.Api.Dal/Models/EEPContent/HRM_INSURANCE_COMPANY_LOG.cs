using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_INSURANCE_COMPANY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? INSURANCE_COMPANY_ID { get; set; }
        public string INSURANCE_COMPANY_CODE { get; set; }
        public string INSURANCE_COMPANY_NAME { get; set; }
        public string TAX_NO { get; set; }
        public string INSURANCE_COMPANY_ADDRESS { get; set; }
        public string INSURANCE_COMPANY_TEL { get; set; }
        public string INSURANCE_COMPANY_CHAIRMAN { get; set; }
        public string LABOR_INSURANCE_NO { get; set; }
        public string HEALTH_INSURANCE_NO { get; set; }
        public string LABOR_INSURANCE_CHECK_NO { get; set; }
        public string HEALTH_INSTITUTION { get; set; }
        public decimal? JOB_ACCIDENT_RATE { get; set; }
        public decimal? PAY_RATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
