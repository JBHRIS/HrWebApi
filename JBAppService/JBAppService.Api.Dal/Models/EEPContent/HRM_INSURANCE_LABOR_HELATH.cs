using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_INSURANCE_LABOR_HELATH
    {
        public string EMPLOYEE_ID { get; set; }
        public string IDNO { get; set; }
        public string NAME_C { get; set; }
        public string EXPENSE_YYMM { get; set; }
        public decimal? EXPENSE { get; set; }
        public decimal? COMPANY_BURDEN { get; set; }
        public string INSURANCE_EXPENSE_TYPE { get; set; }
        public int INSURANCE_COMPANY_ID { get; set; }
        public string GROUP_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
