using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_COST
    {
        public int EMPLOYEE_COST_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? DEPTC_ID { get; set; }
        public int? JOB_ID { get; set; }
        public decimal? RATIO { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
