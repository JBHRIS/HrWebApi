using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_HOLIDAY_OVERTIME_DATA_DETAIL
    {
        public int HOLIDAY_OVERTIME_DATA_DETAIL_ID { get; set; }
        public int HOLIDAY_OVERTIME_DATA_MASTER_ID { get; set; }
        public int? SEQ { get; set; }
        public decimal? RATE_NUM { get; set; }
        public decimal? FIXED_AMT { get; set; }
        public decimal? HOURS { get; set; }
        public decimal? OVERTIME_EXPENSE { get; set; }
        public int? SALARY_ID { get; set; }
    }
}
