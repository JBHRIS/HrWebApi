using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_EXPAND_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int EMPLOYEE_EXPAND_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EXPAND_1 { get; set; }
        public string EXPAND_2 { get; set; }
        public string EXPAND_3 { get; set; }
        public string EXPAND_4 { get; set; }
        public string EXPAND_5 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
