using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_EXPRESSION_SYSTEM
    {
        public string EXPRESSION_CODE { get; set; }
        public string SYSTEM_PARAMETER_CODE { get; set; }
        public string SYSTEM_PARAMETER_TITLE { get; set; }
        public string SYSTEM_PARAMETER_MEMO { get; set; }
        public int? SYSTEM_PARAMETER_SEQ { get; set; }
        public bool IS_FUNCTION { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
