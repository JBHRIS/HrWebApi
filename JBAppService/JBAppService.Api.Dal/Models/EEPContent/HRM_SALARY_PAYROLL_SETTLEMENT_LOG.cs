using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_PAYROLL_SETTLEMENT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public int SALARY_SETTING_ID { get; set; }
        public DateTime SALARY_BEGIN_DATE { get; set; }
        public DateTime SALARY_END_DATE { get; set; }
        public DateTime ATTEND_BEGIN_DATE { get; set; }
        public DateTime ATTEND_END_DATE { get; set; }
        public DateTime SALARY_PARAMETER_DATE { get; set; }
        public decimal OVERTIME_DUTY_FREE_HOURS { get; set; }
        public decimal WELFARE_RATE { get; set; }
        public string WELFARE_SALARY_ITEM { get; set; }
        public string COURT_SALARY_ITEM { get; set; }
        public decimal INCOMETAX_WITHHOLD_TAX { get; set; }
        public decimal INCOMETAX_FIX_RATE { get; set; }
        public decimal INCOMETAX_FOREIGNER_SALARY { get; set; }
        public decimal INCOMETAX_FOREIGNER_RATE { get; set; }
        public decimal INCOMETAX_ENTRYDAY { get; set; }
        public decimal INCOMETAX_ENTRY_RATE { get; set; }
        public decimal INCOMETAX_ENTRY_OVER_RATE { get; set; }
        public decimal SUPPLY_RATE { get; set; }
        public decimal SUPPLY_ANNUAL_RATE { get; set; }
        public decimal SUPPLY_MAXIMUM { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
