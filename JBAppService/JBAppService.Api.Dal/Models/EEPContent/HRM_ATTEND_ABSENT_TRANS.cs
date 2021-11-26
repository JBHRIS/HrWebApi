using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ABSENT_TRANS
    {
        public int ABSENT_TRANS_ID { get; set; }
        public string ABSENT_PLUS_ID { get; set; }
        public string ABSENT_MINUS_ID { get; set; }
        public DateTime? ABSENT_DATE { get; set; }
        public decimal? ABSENT_HOURS { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
