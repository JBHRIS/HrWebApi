using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ABSENT_PLUS
    {
        public int ABSENT_PLUS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public int? HOLIDAY_ID { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
        public decimal? TOTAL_DAY { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public decimal? REST_HOURS { get; set; }
        public string MEMO { get; set; }
        public string ABSENT_PLUS_NO { get; set; }
        public string ABSENT_PLUS_TYPE { get; set; }
        public string SYSCREATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
