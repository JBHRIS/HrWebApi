using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_BIRTHDAY_HOLIDAY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int BIRTHDAY_HOLIDAY_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string BIRTHDAY_YEAR { get; set; }
        public DateTime? BIRTHDAY { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public int? HOLIDAY_ID { get; set; }
        public decimal? TOTAL_HOURS { get; set; }
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
