﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_HEALTH_FAMILY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int EMPLOYEE_HEALTH_FAMILY_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? EMPLOYEE_FAMILY_ID { get; set; }
        public string HEALTH_ALLOWANCE_CODE { get; set; }
        public string HEALTH_LEAVE_CAUSE_CODE { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public string EMPLOYEE_HEALTH_FAMILY_MEMO { get; set; }
        public string REPORT_DONE { get; set; }
        public DateTime? REPORT_DONE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
