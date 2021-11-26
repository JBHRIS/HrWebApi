﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_HOLIDAY_KIND
    {
        public int HOLIDAY_KIND_ID { get; set; }
        public string HOLIDAY_KIND_CODE { get; set; }
        public string HOLIDAY_KIND_CNAME { get; set; }
        public string HOLIDAY_KIND_ENAME { get; set; }
        public int? SORT { get; set; }
        public string UNIT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
