using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SCHOOL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? SCHOOL_ID { get; set; }
        public string SCHOOL_CODE { get; set; }
        public string SCHOOL_CNAME { get; set; }
        public string SCHOOL_ENAME { get; set; }
        public string SCHOOL_IS_OVERSEA { get; set; }
        public int? SCHOOL_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
