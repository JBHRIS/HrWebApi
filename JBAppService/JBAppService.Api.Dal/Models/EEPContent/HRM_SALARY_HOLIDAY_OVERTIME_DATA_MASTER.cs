using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_HOLIDAY_OVERTIME_DATA_MASTER
    {
        public int HOLIDAY_OVERTIME_DATA_MASTER_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public string SALARY_SEQ { get; set; }
        public int HOLIDAY_OVERTIME_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? OVERTIME_DATE { get; set; }
        public string OVERTIME_YYMM { get; set; }
        public decimal? RATE_HOURS_BEGIN { get; set; }
        public decimal? OVERTIME_HOURS { get; set; }
        public decimal? EXPENSE_HOURS { get; set; }
        public decimal? SALARY_AMT { get; set; }
        public int? OVERTIME_RATE_MASTER_ID { get; set; }
        public decimal? HOURLY_RATE { get; set; }
        public bool? IS_FIXED { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
