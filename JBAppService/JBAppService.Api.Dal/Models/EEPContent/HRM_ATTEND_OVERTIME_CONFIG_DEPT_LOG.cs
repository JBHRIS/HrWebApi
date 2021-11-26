using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_OVERTIME_CONFIG_DEPT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int DEPT_ID { get; set; }
        public int? ATTEND_CLOSE_DAY { get; set; }
        public string IS_CHECK_ATTEND_CARD { get; set; }
        public decimal? OVERTIME_UNIT { get; set; }
        public decimal? ALLOW_NORMAL_OVERTIME_HOUR { get; set; }
        public decimal? ALLOW_OFFPAY_OVERTIME_HOUR { get; set; }
        public decimal? ALLOW_HOLIDAY_OVERTIME_HOUR { get; set; }
        public decimal? ALLOW_NATIONAL_HOLIDAY_OVERTIME_HOUR { get; set; }
        public string ALLOW_MODIFY { get; set; }
        public decimal? UPPER_MANAGER_HOUR { get; set; }
        public int? ALLOW_MONTH_OVERTIME_HOUR { get; set; }
        public string IS_CHECK_MONTH_OVERTIME_HOUR { get; set; }
        public string IS_SHOW_MONTH_OVERTIME_HOUR { get; set; }
        public string IS_CHECK_NORMAL_OVERTIME_HOUR { get; set; }
        public string IS_CHECK_OFFPAY_OVERTIME_HOUR { get; set; }
        public string IS_CHECK_HOLIDAY_OVERTIME_HOUR { get; set; }
        public string IS_CHECK_NATIONAL_HOLIDAY_OVERTIME_HOUR { get; set; }
        public string IS_OVERTIME_DEPT { get; set; }
        public string MONTH_HOUR_DATE_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
