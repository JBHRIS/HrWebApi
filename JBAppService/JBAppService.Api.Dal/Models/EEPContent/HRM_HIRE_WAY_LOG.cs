using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_HIRE_WAY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? HIRE_WAY_ID { get; set; }
        public string HIRE_WAY_CODE { get; set; }
        public string HIRE_WAY_CNAME { get; set; }
        public string HIRE_WAY_ENAME { get; set; }
        public int? HIRE_WAY_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
