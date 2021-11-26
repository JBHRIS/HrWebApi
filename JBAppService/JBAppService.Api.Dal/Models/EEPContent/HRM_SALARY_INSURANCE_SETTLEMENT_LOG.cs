using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_INSURANCE_SETTLEMENT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? COMPANY_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public int? SALARY_SETTING_ID { get; set; }
        public DateTime ARRIVE_DATE { get; set; }
        public decimal HEALTH_RATE { get; set; }
        public decimal HEALTH_FAMILY_COUNT { get; set; }
        public decimal HEALTH_COMPANY_COUNT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
