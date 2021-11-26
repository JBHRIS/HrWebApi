using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_HOLIDAY_TYPE
    {
        public int HOLIDAY_TYPE_ID { get; set; }
        public string HOLIDAY_TYPE_CODE { get; set; }
        public string HOLIDAY_TYPE_CNAME { get; set; }
        public string HOLIDAY_TYPE_ENAME { get; set; }
        public string HOLIDAY_TYPE_COLOR { get; set; }
        public string NATIONAL_HOLIDAY { get; set; }
        public string NORMAL_HOLIDAY { get; set; }
        public string REST_HOLIDAY { get; set; }
        public string ROTEMAPPING_CODE { get; set; }
        public int? HOLIDAY_TYPE_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
