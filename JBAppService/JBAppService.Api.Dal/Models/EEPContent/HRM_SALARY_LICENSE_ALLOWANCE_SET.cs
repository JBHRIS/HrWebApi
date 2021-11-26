﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_LICENSE_ALLOWANCE_SET
    {
        public int LICENSE_ID { get; set; }
        public int SALARY_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? LICENSE_TYPE_ID { get; set; }
        public decimal? AMT { get; set; }
        public string BEGIN_YYMM { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
