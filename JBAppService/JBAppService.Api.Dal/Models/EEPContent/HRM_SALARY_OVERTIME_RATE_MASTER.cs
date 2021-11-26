using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_RATE_MASTER
    {
        public int OVERTIME_RATE_MASTER_ID { get; set; }
        public string OVERTIME_RATE_CODE { get; set; }
        public string OVERTIME_RATE_CNAME { get; set; }
        public string OVERTIME_RATE_ENAME { get; set; }
        public int? SEQ { get; set; }
        public bool? IS_FIXED { get; set; }
        public decimal? LIMIT_MINUTE { get; set; }
        public decimal? SPAN_MINUTE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
