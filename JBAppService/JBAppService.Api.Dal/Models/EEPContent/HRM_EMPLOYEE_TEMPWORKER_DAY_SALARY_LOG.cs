using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_TEMPWORKER_DAY_SALARY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int DEPTC_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime WORK_DATE { get; set; }
        public decimal? WORK_HOURS { get; set; }
        public decimal? HOURLY_AMT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
