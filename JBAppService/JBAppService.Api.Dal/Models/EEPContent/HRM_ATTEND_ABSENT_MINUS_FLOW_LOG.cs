using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ABSENT_MINUS_FLOW_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string ABSENT_MINUS_NO { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string BEGIN_TIME { get; set; }
        public string END_TIME { get; set; }
        public DateTime? ABSENT_DATE_TIME_BEGIN { get; set; }
        public DateTime? ABSENT_DATE_TIME_END { get; set; }
        public string AGENT_EMPLOYEE_ID { get; set; }
        public int? HOLIDAY_ID { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public string MEMO { get; set; }
        public string FILE_NAME { get; set; }
        public string FILE_PATH { get; set; }
        public string FLOWFLAG { get; set; }
        public string APPLICATE_ROLE { get; set; }
        public string APPLICATE_USER { get; set; }
        public string ATTEND_GROUP_ID { get; set; }
        public string GROUP_ID { get; set; }
        public int? GRADE_ID { get; set; }
        public string AGENT_USER { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
