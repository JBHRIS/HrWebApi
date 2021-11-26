using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_ABSENT
    {
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public int SALARY_ID { get; set; }
        public decimal? SALBASE_AMT { get; set; }
        public int DEDUCT_SALARY_ID { get; set; }
        public decimal? ABSENT_EXPENSE { get; set; }
        public int ABSENT_MINUS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime ABSENT_DATE { get; set; }
        public int HOLIDAY_ID { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public string BEGIN_TIME { get; set; }
        public string END_TIME { get; set; }
        public DateTime? ABSENT_DATE_TIME_BEGIN { get; set; }
        public DateTime? ABSENT_DATE_TIME_END { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
