﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_HEALTH_LEAVE_CAUSE
    {
        public string HEALTH_LEAVE_CAUSE_CODE { get; set; }
        public string HEALTH_LEAVE_CAUSE_RCODE { get; set; }
        public string HEALTH_LEAVE_CAUSE_CNAME { get; set; }
        public string HEALTH_LEAVE_CAUSE_RNAME { get; set; }
        public string HEALTH_LEAVE_CAUSE_TYPE { get; set; }
        public int? HEALTH_LEAVE_CAUSE_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
