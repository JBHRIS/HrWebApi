using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_SALCODE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int SALARY_ID { get; set; }
        public string SALARY_CODE { get; set; }
        public string SALARY_CNAME { get; set; }
        public string SALARY_ENAME { get; set; }
        public bool? IS_DUTY { get; set; }
        public int SIGN { get; set; }
        public decimal? TAX_RATE { get; set; }
        public bool? IS_DEDUCT { get; set; }
        public int? ACCOUNT_ID { get; set; }
        public int? SEQ { get; set; }
        public string MERGE_SALARY_CNAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
