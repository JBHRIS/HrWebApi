using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_BASETTS_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int ATTEND_BASETTS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime EFFECT_DATE { get; set; }
        public string ATTEND_BASETTS_TYPE { get; set; }
        public int? ROTE_ID { get; set; }
        public int? SHIFT_ID { get; set; }
        public int? CALENDAR_ID { get; set; }
        public int? NORMAL_OVERTIME_RATE_MASTER_ID { get; set; }
        public int? HOLIDAY_OVERTIME_RATE_MASTER_ID { get; set; }
        public int? REST_OVERTIME_RATE_MASTER_ID { get; set; }
        public int? NATIONAL_HOLIDAY_OVERTIME_RATE_MASTER_ID { get; set; }
        public int? ATTEND_GROUP_MASTER_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
