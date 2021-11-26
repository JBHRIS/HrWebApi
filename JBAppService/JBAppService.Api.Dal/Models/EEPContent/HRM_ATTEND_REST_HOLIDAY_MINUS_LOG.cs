using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_REST_HOLIDAY_MINUS_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int REST_HOLIDAY_MINUS_ID { get; set; }
        public int? ABSENT_PLUS_ID { get; set; }
        public int? ABSENT_MINUS_ID { get; set; }
        public int? ABSENT_TRANS_ID { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public decimal? REST_HOURS { get; set; }
        public decimal? REVERSAL_HOURS { get; set; }
        public string IS_SYSCREATE { get; set; }
        public string HAVE_TRANSFER { get; set; }
        public string IS_TRANSFER { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
