using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_PAYROLL_SETTLEMENT_DETAIL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public string SALARY_PAY_TYPE { get; set; }
        public DateTime SALARY_BEGIN_DATE { get; set; }
        public DateTime SALARY_END_DATE { get; set; }
        public DateTime ATTEND_BEGIN_DATE { get; set; }
        public DateTime ATTEND_END_DATE { get; set; }
        public DateTime SALARY_PARAMETER_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
