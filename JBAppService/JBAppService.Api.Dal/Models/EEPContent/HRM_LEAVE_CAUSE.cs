using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_LEAVE_CAUSE
    {
        public int LEAVE_CAUSE_ID { get; set; }
        public string LEAVE_CAUSE_CODE { get; set; }
        public string LEAVE_CAUSE_CNAME { get; set; }
        public string LEAVE_CAUSE_ENAME { get; set; }
        public int? LEAVE_CAUSE_SEQ { get; set; }
        public string IS_COUNT_LEAVE_RATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
