using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_SKILL
    {
        public int EMPLOYEE_SKILL_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? SKILL_ID { get; set; }
        public string EMPLOYEE_SKILL_CONTENT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
