using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_INSURANCE_YEAR_SUMMARY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int YEAR_SUMMARY_ID { get; set; }
        public string INSURANCE_YEAR { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_FAMILY_IDNO { get; set; }
        public decimal? EMPLOYEE_LABOR_AMT { get; set; }
        public decimal? EMPLOYEE_HEALTH_AMT { get; set; }
        public decimal? EMPLOYEE_GROUP_AMT { get; set; }
        public decimal? EMPLOYEE_SUPPLY_AMT { get; set; }
        public string GROUP_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
