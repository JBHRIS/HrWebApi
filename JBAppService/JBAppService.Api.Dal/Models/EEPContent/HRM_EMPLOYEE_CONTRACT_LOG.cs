using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_CONTRACT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int EMPLOYEE_CONTRACT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? CONTRACT_TYPE_ID { get; set; }
        public string EMPLOYEE_CONTRACT_CNAME { get; set; }
        public string EMPLOYEE_CONTRACT_ENAME { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
