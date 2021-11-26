using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_LABOR_ALLOWANCE
    {
        public string LABOR_ALLOWANCE_CODE { get; set; }
        public string LABOR_ALLOWANCE_CNAME { get; set; }
        public decimal? NORMAL_ACCIDENT_RATE { get; set; }
        public decimal? JOBLESS_RATE { get; set; }
        public string JOB_ACCIDENT { get; set; }
        public string PAY { get; set; }
        public decimal? EMPLOYEE_RATE { get; set; }
        public decimal? COMPANY_RATE { get; set; }
        public decimal? PARTIAL_RATE { get; set; }
        public DateTime? VALID_DATE { get; set; }
        public int? LABOR_ALLOWANCE_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
