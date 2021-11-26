using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_HEALTH_CONFIG
    {
        public int COMPANY_ID { get; set; }
        public int? HEALTH_SALARY_ID { get; set; }
        public int? HEALTH_OVERPAY_SALARY_ID { get; set; }
        public int? HEALTH_RECHARGE_SALARY_ID { get; set; }
        public decimal? EMPLOYEE_FAMILY_CNT { get; set; }
        public decimal? COMPANY_PERSON_CNT { get; set; }
        public decimal? HEALTH_COMPANY_RATE { get; set; }
        public int? SUPPLY_SALARY_ID { get; set; }
        public decimal? SUPPLY_RATE { get; set; }
        public decimal? SUPPLY_ANNUAL_RATE { get; set; }
        public decimal? SUPPLY_MAXIMUM { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
