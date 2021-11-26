using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_DUTY_ALLOWANCE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int DUTY_ALLOWANCE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? ATTEND_DATE { get; set; }
        public string BEGIN_TIME { get; set; }
        public string END_TIME { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
        public decimal AMT { get; set; }
        public string SALARY_YYMM { get; set; }
        public int? OVERTIME_ROTE_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
