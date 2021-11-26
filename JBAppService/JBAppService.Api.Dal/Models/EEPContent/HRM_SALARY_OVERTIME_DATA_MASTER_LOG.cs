using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_DATA_MASTER_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? OVERTIME_DATA_MASTER_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_SEQ { get; set; }
        public int? OVERTIME_ID { get; set; }
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
        public decimal? TAXABLE_HOUR { get; set; }
        public decimal? TAXABLE_AMT { get; set; }
        public int? TAXABLE_SALARY_ID { get; set; }
        public decimal? DUTYFREE_HOUR { get; set; }
        public decimal? DUTYFREE_AMT { get; set; }
        public int? DUTYFREE_SALARY_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
