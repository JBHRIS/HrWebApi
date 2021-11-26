using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_IDENTITY
    {
        public int IDENTITY_ID { get; set; }
        public string IDENTITY_CODE { get; set; }
        public string IDENTITY_CNAME { get; set; }
        public string IDENTITY_ENAME { get; set; }
        public int? IDENTITY_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
