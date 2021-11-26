using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_LICENCE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int EMPLOYEE_LICENCE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? LICENCE_ID { get; set; }
        public string LICENCE_NAME { get; set; }
        public string LICENCE_CONTENT { get; set; }
        public string AUTHENTIC_ORG { get; set; }
        public string LICENCE_NO { get; set; }
        public string LICENCE_COUNTRY { get; set; }
        public string LICENCE_OWN { get; set; }
        public string LICENCE_MEMO { get; set; }
        public DateTime? LICENCE_EFFECTIVE_DATE { get; set; }
        public DateTime? LICENCE_VALID_DATE { get; set; }
        public int? SALARY_ID { get; set; }
        public decimal? SALARY_AMT { get; set; }
        public DateTime? SALARY_BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? SALARY_END_EFFECTIVE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
