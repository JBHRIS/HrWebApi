using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_FORM
    {
        public int FORM_ID { get; set; }
        public int? PROJECT_ID { get; set; }
        public string FORM_NAME { get; set; }
        public string FORM_EXPLAIN { get; set; }
        public int? SCALE_ID { get; set; }
        public int? BEHAVIOR_SCALE_ID { get; set; }
        public string GUIDE_BEHAVIOR { get; set; }
        public string GUIDE_OPENENDED { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
