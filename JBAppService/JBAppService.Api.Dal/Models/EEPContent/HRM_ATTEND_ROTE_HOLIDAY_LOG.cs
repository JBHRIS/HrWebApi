﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ROTE_HOLIDAY_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? ROTE_HOLIDAY_ID { get; set; }
        public int? ROTE_ID { get; set; }
        public decimal? BEGIN_HOUR { get; set; }
        public decimal? END_HOUR { get; set; }
        public decimal? REST_HOUR { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
