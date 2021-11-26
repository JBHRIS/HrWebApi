using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_OVERTIME_CAUSE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int OVERTIME_CAUSE_ID { get; set; }
        public string OVERTIME_CAUSE_CODE { get; set; }
        public string OVERTIME_CAUSE_CNAME { get; set; }
        public string OVERTIME_CAUSE_ENAME { get; set; }
        public int? OVERTIME_CAUSE_SEQ { get; set; }
        public string ONCALL { get; set; }
        public string NOT_DISPLAY { get; set; }
        public string NOT_CALCULATE { get; set; }
        public string NOT_FOOD { get; set; }
        public string HOLIDAY_OVERTIME { get; set; }
        public string NOT_CHECKCARD { get; set; }
        public string IS_MEMO { get; set; }
        public int? HOLIDAY_TYPE_ID { get; set; }
        public int? OVERTIME_RATE_MASTER_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
