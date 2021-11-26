using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_LEAVE_CANCEL_FLOW
    {
        public string LEAVE_CANCEL_NO { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? ABSENT_LEAVE_ID { get; set; }
        public string CANCEL_REASON { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public string FLOWFLAG { get; set; }
        public string APPLICATE_ROLE { get; set; }
        public string APPLICATE_USER { get; set; }
        public string FLOW_CONTENT { get; set; }
        public string FLOW_MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
