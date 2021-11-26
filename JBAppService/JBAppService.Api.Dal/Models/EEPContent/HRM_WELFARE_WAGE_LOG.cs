using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_WELFARE_WAGE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? WELFARE_WAGE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public string SALARY_SEQ { get; set; }
        public int? WELFARE_ID { get; set; }
        public decimal? AMT { get; set; }
        public decimal? DEDUCT_TAX_AMT { get; set; }
        public string TAX_FORMAT_CODE { get; set; }
        public string GROUP_ID { get; set; }
        public string IS_IMPORT { get; set; }
        public string WELFARE_COMMITTEE_CODE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
