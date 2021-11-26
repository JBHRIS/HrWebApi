using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_COURT_DEDUCT_SET_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int COURT_DEDUCT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string BEGIN_YYMM { get; set; }
        public string END_YYMM { get; set; }
        public int? SALARY_ID { get; set; }
        public DateTime? EFFECT_DATE { get; set; }
        public bool? IS_COURT_DEDUCT { get; set; }
        public decimal? COURT_DEDUCT_PERCENT { get; set; }
        public decimal? COMBINE_PERCENT { get; set; }
        public decimal? TOTAL_AMT { get; set; }
        public decimal? INSTALLMENT_AMT { get; set; }
        public decimal? LOW_SPEND { get; set; }
        public bool? KEEP_LOW_SPEND { get; set; }
        public int? SEQ { get; set; }
        public bool? IS_STOP { get; set; }
        public string MEMO { get; set; }
        public string REFERENCE_NO { get; set; }
        public string DEBIT_COMPANY { get; set; }
        public string DEBIT_ACCOUNT_NAME { get; set; }
        public string DEBIT_TEL { get; set; }
        public string DEBIT_ADDRESS { get; set; }
        public string COURT_ORGANIZER { get; set; }
        public string COURT_UNDERTAKER { get; set; }
        public string COURT_TEL { get; set; }
        public DateTime? ISSUE_DATE { get; set; }
        public DateTime? RECEIVE_DATE { get; set; }
        public DateTime? DECLARE_DATE { get; set; }
        public DateTime? CLOSE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
