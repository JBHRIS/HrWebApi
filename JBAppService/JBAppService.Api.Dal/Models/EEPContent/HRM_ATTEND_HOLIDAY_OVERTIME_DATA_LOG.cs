using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_HOLIDAY_OVERTIME_DATA_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? HOLIDAY_OVERTIME_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? OVERTIME_DATE { get; set; }
        public string BEGIN_TIME { get; set; }
        public DateTime? OVERTIME_DATE_TIME_BEGIN { get; set; }
        public string END_TIME { get; set; }
        public DateTime? OVERTIME_DATE_TIME_END { get; set; }
        public decimal? OVERTIME_HOURS { get; set; }
        public int? OVERTIME_CAUSE_ID { get; set; }
        public string OVERTIME_NO { get; set; }
        public string SALARY_YYMM { get; set; }
        public string IS_IMPORT { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public int? OVERTIME_ROTE_ID { get; set; }
    }
}
