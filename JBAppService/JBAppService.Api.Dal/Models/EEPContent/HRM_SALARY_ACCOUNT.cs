using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_ACCOUNT
    {
        public int ACCOUNT_ID { get; set; }
        public string ACCOUNT_CODE { get; set; }
        public string ACCOUNT_CNAME { get; set; }
        public string ACCOUNT_ENAME { get; set; }
        public string ACCOUNT_ATTRIBUTE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
