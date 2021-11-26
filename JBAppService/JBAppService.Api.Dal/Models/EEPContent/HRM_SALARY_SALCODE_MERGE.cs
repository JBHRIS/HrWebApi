﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_SALCODE_MERGE
    {
        public int SALARY_MERGE_ID { get; set; }
        public int? PARENT_SALARY_ID { get; set; }
        public int? MERGE_SALARY_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
