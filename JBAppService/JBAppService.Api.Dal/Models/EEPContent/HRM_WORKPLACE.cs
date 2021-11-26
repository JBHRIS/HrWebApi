﻿using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_WORKPLACE
    {
        public int WORK_ID { get; set; }
        public string WORK_CODE { get; set; }
        public string WORK_ADDR { get; set; }
        public int? WORK_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
