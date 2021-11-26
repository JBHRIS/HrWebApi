using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CALENDAR_HOLIDAY
    {
        public int CALENDAR_HOLIDAY_ID { get; set; }
        public DateTime CALENDAR_HOLIDAY_DATE { get; set; }
        public int HOLIDAY_TYPE_ID { get; set; }
        public int CALENDAR_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
