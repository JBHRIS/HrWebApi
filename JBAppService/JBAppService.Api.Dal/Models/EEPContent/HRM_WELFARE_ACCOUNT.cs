using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_WELFARE_ACCOUNT
    {
        public int EMPLOYEE_ACCOUNT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? BANK_ID { get; set; }
        public string ACCOUNT_NO { get; set; }
        public int? CURRENCY_ID { get; set; }
        public decimal? ACCOUNT_PERCENT { get; set; }
        public decimal? ACCOUNT_QUOTA { get; set; }
        public int? ACCOUNT_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
