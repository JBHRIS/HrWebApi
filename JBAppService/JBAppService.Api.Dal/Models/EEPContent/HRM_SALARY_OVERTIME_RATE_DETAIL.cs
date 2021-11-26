using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_RATE_DETAIL
    {
        public int OVERTIME_RATE_DETAIL_ID { get; set; }
        public int OVERTIME_RATE_MASTER_ID { get; set; }
        public decimal? BEGIN_HOUR { get; set; }
        public decimal? END_HOUR { get; set; }
        public decimal? RATE_NUM { get; set; }
        public decimal? FIXED_AMT { get; set; }
        public int? TIME_TYPE { get; set; }
        public int? FREE_SALARY_ID { get; set; }
        public int? TAX_SALARY_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
