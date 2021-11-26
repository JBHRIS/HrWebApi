using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ROTEMAPPING_HOUR_PATCH_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int ROTEMAPPING_HOUR_PATCH_ID { get; set; }
        public int ROTEMAPPING_CODE { get; set; }
        public int ROTE_ID { get; set; }
        public decimal? HOUR_BEGIN { get; set; }
        public decimal? HOUR_END { get; set; }
        public decimal? PATCH_HOUR { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
