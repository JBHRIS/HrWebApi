﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_BASETTS
    {
        public int SALARY_BASETTS_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime EFFECT_DATE { get; set; }
        public decimal? WITHHOLDING_INCOMETAX { get; set; }
        public decimal? DEPENDENTS { get; set; }
        public bool? IS_TAX_FIXED { get; set; }
        public int? SALARY_GROUP_MASTER_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
