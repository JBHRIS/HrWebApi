using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CARD_COLLECT_DETAIL
    {
        public string CARD_COLLECT_CODE { get; set; }
        public string COLLECT_CODE { get; set; }
        public int MATCHE_INDEX { get; set; }
        public int LENGTH { get; set; }
        public string IGNORE { get; set; }
        public string FORMAT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
