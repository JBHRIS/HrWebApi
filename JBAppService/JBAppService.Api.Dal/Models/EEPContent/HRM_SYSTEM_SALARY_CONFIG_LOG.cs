using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_SALARY_CONFIG_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int COMPANY_ID { get; set; }
        public int? WELFARE_SALARY_ID { get; set; }
        public decimal? WELFARE_RATE { get; set; }
        public int? ATTEND_CLOSE_DAY { get; set; }
        public int? SALARY_CLOSE_DAY { get; set; }
        public int? FULL_ATTEND_SALARY_ID { get; set; }
        public int? TRAFFIC_SALARY_ID { get; set; }
        public int? FOOD_SALARY_ID { get; set; }
        public int? HOUR_SALARY_ID { get; set; }
        public string SHIFT_ALLOWANCE_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
