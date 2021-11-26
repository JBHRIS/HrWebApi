using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ABSENT_MINUS_FLOW_DETAIL
    {
        public int ABSENT_MINUS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime ABSENT_DATE { get; set; }
        public int HOLIDAY_ID { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public string BEGIN_TIME { get; set; }
        public string END_TIME { get; set; }
        public DateTime? ABSENT_DATE_TIME_BEGIN { get; set; }
        public DateTime? ABSENT_DATE_TIME_END { get; set; }
        public string SALARY_YYMM { get; set; }
    }
}
