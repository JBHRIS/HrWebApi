﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_FESTIVAL
    {
        public string EMPLOYEE_ID { get; set; }
        public string EFFECT_YYMM { get; set; }
        public string SALARY_YYMM { get; set; }
        public int SALARY_ID { get; set; }
        public decimal? AMT { get; set; }
        public string TRANSFER_YYMM { get; set; }
        public string TRANSFER_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
