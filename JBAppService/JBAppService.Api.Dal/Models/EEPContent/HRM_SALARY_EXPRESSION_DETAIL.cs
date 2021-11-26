﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_EXPRESSION_DETAIL
    {
        public string EXPRESSION_CODE { get; set; }
        public string PARAMETER_CODE { get; set; }
        public string PARAMETER_TITLE { get; set; }
        public string PARAMETER_MEMO { get; set; }
        public string PARAMETER_FORMULA { get; set; }
        public int? PARAMETER_SEQ { get; set; }
        public string SYSTEM_CODE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
