using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_RELATION
    {
        public int RELATION_ID { get; set; }
        public string RELATION_CODE { get; set; }
        public string RELATION_NAME { get; set; }
        public string GROUP_RELATION_CODE { get; set; }
        public int? RELATION_SEQ { get; set; }
        public int? HEALTH_RELATION_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
