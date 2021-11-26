using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_BASE_BASETTS
    {
        public int BASETTS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime EFFECT_DATE { get; set; }
        public int? COMPANY_ID { get; set; }
        public int? DEPT_ID { get; set; }
        public int? DEPTC_ID { get; set; }
        public int? DEPTA_ID { get; set; }
        public int? GRADE_ID { get; set; }
        public int? LEVEL_ID { get; set; }
        public int? JOB_ID { get; set; }
        public int? JOB_FUNCTION_ID { get; set; }
        public int? JOB_CLASS_ID { get; set; }
        public int? IDENTITY_ID { get; set; }
        public int? WORK_ID { get; set; }
        public string DIRECT_INDIRECT { get; set; }
        public string GROUP_ID { get; set; }
        public string ATTEND_GROUP_ID { get; set; }
        public string EMPLOYEE_GROUP_ID { get; set; }
        public int? DOORGUARD_ID { get; set; }
        public int? ALTERATION_CAUSE_ID { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
