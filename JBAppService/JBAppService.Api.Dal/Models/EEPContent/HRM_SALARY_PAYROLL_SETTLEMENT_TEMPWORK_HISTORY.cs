using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_PAYROLL_SETTLEMENT_TEMPWORK_HISTORY
    {
        public int SETTLEMENT_HISTORY_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string EXECUTE_TYPE { get; set; }
        public string SALARY_PAY_TYPE { get; set; }
        public DateTime EXECUTE_DATE { get; set; }
        public string EXECUTE_MAN { get; set; }
        public string DATA_CONTENT { get; set; }
    }
}
