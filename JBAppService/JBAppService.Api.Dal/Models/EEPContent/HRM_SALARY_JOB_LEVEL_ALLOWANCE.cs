using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_JOB_LEVEL_ALLOWANCE
    {
        public int LEVEL_ID { get; set; }
        public int GRADE_ID { get; set; }
        public decimal? JOB_LEVEL_AMT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
