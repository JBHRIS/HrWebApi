using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_DEPTA
    {
        public int DEPTA_ID { get; set; }
        public string DEPTA_CODE { get; set; }
        public string DEPTA_CNAME { get; set; }
        public string DEPTA_ENAME { get; set; }
        public decimal? DEPTA_PERSON { get; set; }
        public string DEPTA_TREE { get; set; }
        public DateTime? BEGIN_EFFECTIVE_DATE { get; set; }
        public DateTime? END_EFFECTIVE_DATE { get; set; }
        public int? UPPER_DEPTA_ID { get; set; }
        public string DEPTA_MANAGER { get; set; }
        public string ALERT_EMAIL { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
