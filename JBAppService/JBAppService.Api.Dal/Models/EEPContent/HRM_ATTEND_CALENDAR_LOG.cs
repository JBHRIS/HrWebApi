using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CALENDAR_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int CALENDAR_ID { get; set; }
        public string CALENDAR_CODE { get; set; }
        public string CALENDAR_CNAME { get; set; }
        public string CALENDAR_ENAME { get; set; }
        public int? CALENDAR_SEQ { get; set; }
        public string WEEKLY_CYCLE_BASE { get; set; }
        public string CHECK_ROTE_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
