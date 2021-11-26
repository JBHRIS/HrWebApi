using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_SETTLEMENT_SALARY
    {
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_PAYTYPE { get; set; }
        public DateTime ATTEND_BEGIN_DATE { get; set; }
        public DateTime ATTEND_END_DATE { get; set; }
        public DateTime SALARY_BEGIN_DATE { get; set; }
        public DateTime SALARY_END_DATE { get; set; }
        public DateTime SALARY_PARAMETER_DATE { get; set; }
        public DateTime ARRIVE_DATE { get; set; }
        public decimal HEALTH_RATE { get; set; }
        public decimal HEALTH_FAMILY_COUNT { get; set; }
        public decimal HEALTH_COMPANY_COUNT { get; set; }
        public decimal OVERTIME_DUTY_FREE_HOURS { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
