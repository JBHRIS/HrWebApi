using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_MEDIA_TAX_YEAR_PEOPLE
    {
        public int MEDIA_TAX_PEOPLE_ID { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string SALARY_YYMM { get; set; }
        public string SALARY_SEQ { get; set; }
        public int? SALARY_ID { get; set; }
        public decimal? TOTAL_AMOUNT_PAID { get; set; }
        public decimal? NET_WITHHOLDING_TAX { get; set; }
        public string TAX_FORMAT_CODE { get; set; }
        public string MEMO { get; set; }
        public string TAX_INDUSTRIAL_CODE { get; set; }
        public string HOUSE_TAX_NUMBER { get; set; }
        public string TAX_PAYMENT_ITEM_CODE { get; set; }
        public int? COMPANY_ID { get; set; }
        public decimal? SUPPLY_AMT { get; set; }
        public string GROUP_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
