using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_SHIFT_ROTE
    {
        public int SHIFT_ID { get; set; }
        public int SHIFT_SEQ { get; set; }
        public int? ROTE_ID { get; set; }
        public int? SHIFT_DAY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
