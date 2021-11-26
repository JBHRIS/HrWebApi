using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_EXPERIENCE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int EMPLOYEE_EXPERIENCE_ID { get; set; }
        public int EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_EXPERIENCE_COMPANY { get; set; }
        public string EMPLOYEE_EXPERIENCE_DEPARTMENT { get; set; }
        public string EMPLOYEE_EXPERIENCE_JOB { get; set; }
        public string EMPLOYEE_EXPERIENCE_BOSS { get; set; }
        public decimal? EMPLOYEE_EXPERIENCE_SALARY { get; set; }
        public int? CURRENCY_ID { get; set; }
        public DateTime? EMPLOYEE_EXPERIENCE_START { get; set; }
        public DateTime? EMPLOYEE_EXPERIENCE_END { get; set; }
        public decimal? EMPLOYEE_EXPERIENCE_YEAR { get; set; }
        public string EMPLOYEE_EXPERIENCE_LEAVE_REASON { get; set; }
        public string EMPLOYEE_EXPERIENCE_CONTENT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
