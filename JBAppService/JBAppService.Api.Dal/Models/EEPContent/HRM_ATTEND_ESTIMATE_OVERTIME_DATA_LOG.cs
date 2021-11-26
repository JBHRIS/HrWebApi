using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ESTIMATE_OVERTIME_DATA_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int ESTIMATE_OVERTIME_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? OVERTIME_DATE { get; set; }
        public string BEGIN_TIME { get; set; }
        public DateTime? OVERTIME_DATE_TIME_BEGIN { get; set; }
        public string END_TIME { get; set; }
        public DateTime? OVERTIME_DATE_TIME_END { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
        public decimal? OVERTIME_HOURS { get; set; }
        public decimal? REST_HOURS { get; set; }
        public decimal? CHECK_OVERTIME_HOURS { get; set; }
        public decimal? CHECK_REST_HOURS { get; set; }
        public decimal? ACTUAL_OVERTIME_HOURS { get; set; }
        public decimal? ACTUAL_REST_HOURS { get; set; }
        public string ACTUAL_BEGIN_TIME { get; set; }
        public string ACTUAL_END_TIME { get; set; }
        public int? OVERTIME_CAUSE_ID { get; set; }
        public int? OVERTIME_ROTE_ID { get; set; }
        public int? OVERTIME_DEPT_ID { get; set; }
        public DateTime? OVERTIME_EFFECT_DATE { get; set; }
        public string OVERTIME_NO { get; set; }
        public string SALARY_YYMM { get; set; }
        public string IS_IMPORT { get; set; }
        public string IS_TRANSFER { get; set; }
        public string IS_SUCCESS { get; set; }
        public int? OVERTIME_ID { get; set; }
        public string MEMO { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public int? OVERTIME_RATE_MASTER_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
