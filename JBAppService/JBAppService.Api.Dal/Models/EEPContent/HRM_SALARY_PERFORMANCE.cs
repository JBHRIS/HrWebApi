using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_PERFORMANCE
    {
        public int SALARY_PERFORMANCE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string PERFORMANCE_YYMM { get; set; }
        public DateTime? PAY_DATE { get; set; }
        public decimal? PERFORMANCE_AMT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
