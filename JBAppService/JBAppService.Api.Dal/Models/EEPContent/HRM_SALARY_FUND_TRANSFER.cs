using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_FUND_TRANSFER
    {
        public int FUND_TRANSFER_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public int? COMPANY_ID { get; set; }
        public string SALARY_SEQ { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? BANK_ID { get; set; }
        public string TRANSFER_BANK_ACCOUNT { get; set; }
        public decimal? ACCOUNT_PERCENT { get; set; }
        public decimal? ACCOUNT_QUOTA { get; set; }
        public decimal? AMT { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
