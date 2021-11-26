using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EDUCATIONAL
    {
        public int EDUCATIONAL_ID { get; set; }
        public string EDUCATIONAL_CODE { get; set; }
        public string EDUCATIONAL_CNAME { get; set; }
        public string EDUCATIONAL_ENAME { get; set; }
        public int? EDUCATIONAL_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
