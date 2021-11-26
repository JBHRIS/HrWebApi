using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_HOLIDAY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int HOLIDAY_ID { get; set; }
        public string HOLIDAY_CODE { get; set; }
        public string HOLIDAY_CNAME { get; set; }
        public string HOLIDAY_ENAME { get; set; }
        public string HOLIDAY_UNIT { get; set; }
        public decimal? MIN_NUM { get; set; }
        public string INCLUDE_HOLIDAY { get; set; }
        public string SYSTEM_CALCULATE { get; set; }
        public string CALCULATE_OVERTIME { get; set; }
        public string NOT_PRINT { get; set; }
        public string EFFECT_FULL_ATTEND { get; set; }
        public decimal? MAX_NUM { get; set; }
        public string CHECK_REST_HOUR { get; set; }
        public string NOT_SUM { get; set; }
        public string EFFECT_FOOD { get; set; }
        public string EFFECT_SHIFT { get; set; }
        public string SEX { get; set; }
        public string IS_DISPLAY { get; set; }
        public string ABSENT_REASON { get; set; }
        public decimal? ABSENT_UNIT { get; set; }
        public string AUTO_DISPATCH { get; set; }
        public string ALLOW_MANUAL { get; set; }
        public string ALLOW_CREATE_ABSENT { get; set; }
        public string APPLY_LIMIT_TYPE { get; set; }
        public string APPLY_LIMIT_DAY { get; set; }
        public decimal? APPLY_LIMIT_TIME { get; set; }
        public string AGENT_LIMIT { get; set; }
        public string IS_DOCUMENT { get; set; }
        public int? HOLIDAY_SEQ { get; set; }
        public int? HOLIDAY_KIND_ID { get; set; }
        public decimal? UPPER_MANAGER_HOUR { get; set; }
        public string HOLIDAY_FLAG { get; set; }
        public string AUTO_CREATE { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
