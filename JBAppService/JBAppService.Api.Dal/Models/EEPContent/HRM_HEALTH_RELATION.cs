using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_HEALTH_RELATION
    {
        public int HEALTH_RELATION_ID { get; set; }
        public string HEALTH_RELATION_CODE { get; set; }
        public string HEALTH_RELATION_CNAME { get; set; }
        public string HEALTH_RELATION_ENAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
