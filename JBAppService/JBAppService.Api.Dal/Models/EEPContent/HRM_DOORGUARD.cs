using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_DOORGUARD
    {
        public int DOORGUARD_ID { get; set; }
        public string DOORGUARD_CODE { get; set; }
        public string DOORGUARD_CNAME { get; set; }
        public string DOORGUARD_ENAME { get; set; }
        public int? DOORGUARD_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
