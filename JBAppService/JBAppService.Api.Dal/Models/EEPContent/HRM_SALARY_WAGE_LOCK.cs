using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_WAGE_LOCK
    {
        public string SALARY_YYMM { get; set; }
        public int COMPANY_ID { get; set; }
        public string SALARY_SEQ { get; set; }
        public string GROUP_ID { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
