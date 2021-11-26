using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_DATA_DETAIL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int OVERTIME_DATA_DETAIL_ID { get; set; }
        public int OVERTIME_DATA_MASTER_ID { get; set; }
        public string SALARY_SEQ { get; set; }
        public int? SEQ { get; set; }
        public decimal? RATE_NUM { get; set; }
        public decimal? FIXED_AMT { get; set; }
        public int? TIME_TYPE { get; set; }
        public decimal? HOURS { get; set; }
        public bool? IS_TAXABLE { get; set; }
        public decimal? OVERTIME_EXPENSE { get; set; }
        public int? SALARY_ID { get; set; }
    }
}
