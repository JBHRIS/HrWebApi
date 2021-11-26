using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_HOLIDAY_ROTE_CHANGE_DETAIL
    {
        public string EMPLOYEE_ID { get; set; }
        public DateTime HOLIDAY_ROTE_DATE { get; set; }
        public int? ROTE_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
