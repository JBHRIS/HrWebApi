using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_FAMILY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? EMPLOYEE_FAMILY_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? RELATION_ID { get; set; }
        public string EMPLOYEE_FAMILY_NAME { get; set; }
        public string EMPLOYEE_FAMILY_SEX { get; set; }
        public string EMPLOYEE_FAMILY_IDNO { get; set; }
        public DateTime? EMPLOYEE_FAMILY_BIRTHDAY { get; set; }
        public string IS_SUPPORT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
