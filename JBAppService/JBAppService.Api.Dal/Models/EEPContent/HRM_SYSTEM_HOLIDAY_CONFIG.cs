using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_HOLIDAY_CONFIG
    {
        public int COMPANY_ID { get; set; }
        public int? COUNT_TYPE { get; set; }
        public int? EFFECTIVE_DATE_TYPE { get; set; }
        public int? DAY1 { get; set; }
        public int? DAY2 { get; set; }
        public int? DAY3 { get; set; }
        public int? DAY4 { get; set; }
        public int? DAY5 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
