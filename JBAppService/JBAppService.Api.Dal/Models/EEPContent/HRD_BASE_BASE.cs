using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_BASE_BASE
    {
        public int EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string NAME_C { get; set; }
        public string NAME_E { get; set; }
        public string COMPANY_MAIL { get; set; }
        public DateTime? GROUP_EFFECT_DATE { get; set; }
        public int? COMPANY_ID { get; set; }
        public string JOB_CNAME { get; set; }
        public string DEPT_CNAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
