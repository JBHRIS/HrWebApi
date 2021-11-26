using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_LABOR_CONFIG
    {
        public int COMPANY_ID { get; set; }
        public int? LABOR_SALARY_ID { get; set; }
        public int? LABOR_OVERPAY_SALARY_ID { get; set; }
        public int? LABOR_RECHARGE_SALARY_ID { get; set; }
        public decimal? OLD_RETIRE_RATE_DL { get; set; }
        public decimal? OLD_RETIRE_RATE_IDL { get; set; }
        public decimal? NEW_RETIRE_RATE_DL { get; set; }
        public decimal? NEW_RETIRE_RATE_IDL { get; set; }
        public int? RETIRE_SALARY_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
