using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class View_SYS_TODOLIST
    {
        public string FLOW_DESC { get; set; }
        public string APPLICANT { get; set; }
        public string S_STEP_ID { get; set; }
        public string D_STEP_ID { get; set; }
        public string USERNAME { get; set; }
        public string BILLNO { get; set; }
        public string AUDITOR { get; set; }
        public string APPLYDESCR { get; set; }
        public string UPDATEDATE { get; set; }
        public int? HOURS { get; set; }
    }
}
