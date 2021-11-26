using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_ASSESSMENT_PARAMETER_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? ASSESSMENT_PARAMETER_ID { get; set; }
        public string ASSESSMENT_PARAMETER_CODE { get; set; }
        public string ASSESSMENT_PARAMETER_NAME { get; set; }
        public string ASSESSMENT_PARAMETER_TYPE { get; set; }
        public decimal? COEFFICIENT { get; set; }
        public decimal? DAYS { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
