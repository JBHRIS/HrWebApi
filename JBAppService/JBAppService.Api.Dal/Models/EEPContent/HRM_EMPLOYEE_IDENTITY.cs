using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_IDENTITY
    {
        public int EMPLOYEE_IDENTITY_ID { get; set; }
        public string EMPLOYEE_IDENTITY_CODE { get; set; }
        public string EMPLOYEE_IDENTITY_CNAME { get; set; }
        public string EMPLOYEE_IDENTITY_ENAME { get; set; }
        public int? EMPLOYEE_IDENTITY_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
