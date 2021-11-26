﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_SHIFT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int SHIFT_ID { get; set; }
        public string SHIFT_CODE { get; set; }
        public string SHIFT_CNAME { get; set; }
        public string SHIFT_ENAME { get; set; }
        public string SHIFT_FREQUENCE { get; set; }
        public decimal? SHIFT_FREQUENCE_DAY { get; set; }
        public string WEEK_START { get; set; }
        public string SHIFT_HOLIDAY { get; set; }
        public DateTime? BEGIN_EFFECT_DATE { get; set; }
        public int? SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
