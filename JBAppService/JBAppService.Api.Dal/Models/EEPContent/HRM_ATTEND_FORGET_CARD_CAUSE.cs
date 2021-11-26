using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_FORGET_CARD_CAUSE
    {
        public int FORGET_CARD_CAUSE_ID { get; set; }
        public string FORGET_CARD_CAUSE_CODE { get; set; }
        public string FORGET_CARD_CAUSE_CNAME { get; set; }
        public string FORGET_CARD_CAUSE_ENAME { get; set; }
        public int? PERFORMANCE_SCORE { get; set; }
        public int? FORGET_CARD_CAUSE_SEQ { get; set; }
        public string EFFECT_FULL_ATTEND { get; set; }
        public string NOT_TEMP_CARD { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
