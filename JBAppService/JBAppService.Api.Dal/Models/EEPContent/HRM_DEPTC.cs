using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_DEPTC
    {
        public int DEPTC_ID { get; set; }
        public string DEPTC_CODE { get; set; }
        public string DEPTC_CNAME { get; set; }
        public string DEPTC_ENAME { get; set; }
        public string DEPTC_TYPE { get; set; }
        public int? DIRECT_EXPENSE_ID { get; set; }
        public int? INDIRECT_EXPENSE_ID { get; set; }
        public decimal? DEPTC_PERSON { get; set; }
        public string DEPTC_TREE { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public int? UPPER_DEPTC_ID { get; set; }
        public string DEPTC_MANAGER { get; set; }
        public string ALERT_EMAIL { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
