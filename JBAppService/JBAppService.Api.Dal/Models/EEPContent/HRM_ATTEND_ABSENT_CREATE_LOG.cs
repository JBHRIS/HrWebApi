using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ABSENT_CREATE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int ABSENT_CREATE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string BEGIN_TIME { get; set; }
        public string END_TIME { get; set; }
        public DateTime? ABSENT_DATE_TIME_BEGIN { get; set; }
        public DateTime? ABSENT_DATE_TIME_END { get; set; }
        public int? HOLIDAY_ID { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
        public decimal? TOTAL_DAY { get; set; }
        public string SALARY_YYMM { get; set; }
        public string MEMO { get; set; }
        public string NOT_ALLOW_MODIFY { get; set; }
        public string IS_TRANSFER { get; set; }
        public string ABSENT_MINUS_ID { get; set; }
        public string SYSCREATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
