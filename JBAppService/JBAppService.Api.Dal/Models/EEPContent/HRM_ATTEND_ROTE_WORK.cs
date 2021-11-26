using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ROTE_WORK
    {
        public int ROTE_WORK_ID { get; set; }
        public int? ROTE_ID { get; set; }
        public int? WORK_SEQ { get; set; }
        public string WORK_BEGIN_TIME { get; set; }
        public string WORK_END_TIME { get; set; }
        public int? OFF_TIME_LATEST { get; set; }
        public int? ON_TIME_EARLIEST { get; set; }
        public int? LATE_MINUTE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
