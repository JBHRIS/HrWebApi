using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_WAGE_SPECIAL_BONUS
    {
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_SEQ { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
        public int? TRANSFER_BANK_ID { get; set; }
        public string TRANSFER_BANK_ACCOUNT { get; set; }
        public decimal? WORK_DAYS { get; set; }
        public string CASH { get; set; }
        public string MEMO { get; set; }
        public DateTime? CALCULATE_BEGIN_DATE { get; set; }
        public DateTime? CALCULATE_END_DATE { get; set; }
        public string TAX_FORMAT_CODE { get; set; }
        public decimal? TAX_RATE { get; set; }
        public string GROUP_ID { get; set; }
        public DateTime? ATTEND_BEGIN_DATE { get; set; }
        public DateTime? ATTEND_END_DATE { get; set; }
        public string SALARY_FLAG { get; set; }
        public string NOT_COUNT_SALARY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
