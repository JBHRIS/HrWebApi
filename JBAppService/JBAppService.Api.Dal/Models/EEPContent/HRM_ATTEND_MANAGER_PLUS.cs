﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_MANAGER_PLUS
    {
        public int MANAGER_PLUS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string PTO_YEARS { get; set; }
        public string PTO_MONTH { get; set; }
        public string DEPT_ID { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public decimal? PTO_DAYS { get; set; }
        public string UNIT { get; set; }
        public string IS_SYSCREATE { get; set; }
        public string HAVE_TRANSFER { get; set; }
        public string IS_TRANSFER { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
