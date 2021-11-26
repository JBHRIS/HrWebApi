using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ROTE_CHANGE_FLOW
    {
        public int ROTE_CHANGE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string ROTE_ID { get; set; }
        public string IS_CHANGE_HOLIDAY { get; set; }
        public string MEMO { get; set; }
        public string FLOW_CONTENT { get; set; }
        public string APPLICATE_ROLE { get; set; }
        public string APPLICATE_USER { get; set; }
        public string FLOWFLAG { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
