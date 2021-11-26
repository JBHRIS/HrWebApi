using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_MONTH_MEETING_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? MONTH_MEETING_ID { get; set; }
        public string MONTH_MEETING_NAME { get; set; }
        public DateTime? MONTH_MEETING_DATE { get; set; }
        public string MONTH_MEETING_GROUP { get; set; }
        public string MONTH_MEETING_LATE_TIME { get; set; }
        public string MONTH_MEETING_MEMO { get; set; }
        public string MONTH_MEETING_APPROVE_EMPLOYEE_ID { get; set; }
        public DateTime? MONTH_MEETING_APPROVE_DATE { get; set; }
        public string SALARY_YYMM { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
