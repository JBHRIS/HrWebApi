using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_STOCK_TRUST
    {
        public int STOCK_TRUST_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public string SALARY_SEQ { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EXPENSE_TYPE { get; set; }
        public int SALARY_ID { get; set; }
        public decimal AMT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
