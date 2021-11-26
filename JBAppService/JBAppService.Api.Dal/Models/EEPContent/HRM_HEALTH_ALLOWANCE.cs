using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_HEALTH_ALLOWANCE
    {
        public string HEALTH_ALLOWANCE_CODE { get; set; }
        public string HEALTH_ALLOWANCE_CNAME { get; set; }
        public decimal? EMPLOYEE_RATE { get; set; }
        public decimal? COMPANY_RATE { get; set; }
        public decimal? PARTIAL_RATE { get; set; }
        public decimal? FIX_AMT { get; set; }
        public DateTime? VALID_DATE { get; set; }
        public decimal? HEALTH_ALLOWANCE_LIMIT { get; set; }
        public int? HEALTH_ALLOWANCE_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
