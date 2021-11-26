using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_TAX_CONFIG_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int COMPANY_ID { get; set; }
        public int? TAX_SALARY_ID { get; set; }
        public decimal? WITHHOLD_TAX { get; set; }
        public decimal? TAX_FIX_RATE { get; set; }
        public decimal? FOREIGNER_SALARY { get; set; }
        public decimal? FOREIGNER_SALARY_RATE { get; set; }
        public decimal? ENTRYDAY { get; set; }
        public decimal? OVER_RATE { get; set; }
        public decimal? NOT_OVER_RATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
