using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SKILL
    {
        public int SKILL_ID { get; set; }
        public string SKILL_CODE { get; set; }
        public string SKILL_CNAME { get; set; }
        public string SKILL_ENAME { get; set; }
        public int? SKILL_SEQ { get; set; }
        public string SKILL_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
