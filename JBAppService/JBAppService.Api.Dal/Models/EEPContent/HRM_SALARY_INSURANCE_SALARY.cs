using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_INSURANCE_SALARY
    {
        public int INSURANCE_SALARY_ID { get; set; }
        public int? COMPANY_ID { get; set; }
        public string SALARY_YYMM { get; set; }
        public DateTime? EXECUTE_DATE { get; set; }
        public string EXECUTE_MAN { get; set; }
        public bool? IS_PREV_MONTH { get; set; }
        public string ACTION_LIST { get; set; }
    }
}
