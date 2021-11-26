using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_FLOW_EMPLOYEE_ROLE_MAPPING
    {
        public string FLOW_TYPE { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? DEPTA_ID { get; set; }
        public string ROLE_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
