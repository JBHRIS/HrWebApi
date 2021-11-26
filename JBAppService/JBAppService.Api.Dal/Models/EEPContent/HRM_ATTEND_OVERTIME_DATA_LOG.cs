using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_OVERTIME_DATA_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? OVERTIME_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? OVERTIME_DATE { get; set; }
        public string BEGIN_TIME { get; set; }
        public DateTime? OVERTIME_DATE_TIME_BEGIN { get; set; }
        public string END_TIME { get; set; }
        public DateTime? OVERTIME_DATE_TIME_END { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
        public decimal? OVERTIME_HOURS { get; set; }
        public decimal? REST_HOURS { get; set; }
        public int? OVERTIME_CAUSE_ID { get; set; }
        public int? OVERTIME_ROTE_ID { get; set; }
        public int? OVERTIME_DEPT_ID { get; set; }
        public DateTime? OVERTIME_EFFECT_DATE { get; set; }
        public string OVERTIME_NO { get; set; }
        public string SALARY_YYMM { get; set; }
        public int? OVERTIME_RATE_MASTER_ID { get; set; }
        public string SYSTEM_HOLIDAY { get; set; }
        public string SYSTEM_CREATE { get; set; }
        public string NOT_ALLOW_MODIFY { get; set; }
        public string IS_IMPORT { get; set; }
        public string MEMO { get; set; }
        public string FLOWFLAG { get; set; }
        public string CREATE_EMPLOYEE_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
