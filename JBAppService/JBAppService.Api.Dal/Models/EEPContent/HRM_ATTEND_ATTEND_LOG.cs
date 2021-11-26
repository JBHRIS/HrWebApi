using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ATTEND_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int ATTEND_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? ATTEND_DATE { get; set; }
        public int? ROTE_ID { get; set; }
        public int? ACTUAL_ROTE_ID { get; set; }
        public int? HOLIDAY_ROTE_ID { get; set; }
        public decimal? ACTUAL_ATTEND_HRS { get; set; }
        public decimal? ABSENT_HRS { get; set; }
        public decimal? OVERTIME_HRS { get; set; }
        public decimal? LATE_MINS { get; set; }
        public decimal? EARLY_MINS { get; set; }
        public string IS_ABSENT { get; set; }
        public decimal? FORGET_CARD_CNT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
