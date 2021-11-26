using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_OVERTIME_CONFIG_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int COMPANY_ID { get; set; }
        public int? TAX_FREE_SALARY_ID { get; set; }
        public int? TAX_SALARY_ID { get; set; }
        public decimal? DUTY_FREE_HOURS { get; set; }
        public decimal? MALE_MAX_HRS { get; set; }
        public decimal? FEMALE_MAX_HRS { get; set; }
        public decimal? OVERTIME_UNIT { get; set; }
        public int? HOLIDAY_ID { get; set; }
        public string ALLOW_MODIFY { get; set; }
        public decimal? UPPER_MANAGER_HOUR { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
