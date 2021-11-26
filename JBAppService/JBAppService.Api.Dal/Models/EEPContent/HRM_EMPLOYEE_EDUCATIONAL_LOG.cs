using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_EDUCATIONAL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? EMPLOYEE_EDUCATIONAL_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? SCHOOL_ID { get; set; }
        public int? COURSE_SETS_ID { get; set; }
        public int? EDUCATIONAL_ID { get; set; }
        public string SCHOOL_CNAME { get; set; }
        public string COURSE_SETS_CNAME { get; set; }
        public string EMPLOYEE_EDUCATIONAL_TYPE { get; set; }
        public string EMPLOYEE_ADMISSION_DATE { get; set; }
        public string EMPLOYEE_GRADUATION_DATE { get; set; }
        public string EMPLOYEE_GRADUATION_TREATISE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
