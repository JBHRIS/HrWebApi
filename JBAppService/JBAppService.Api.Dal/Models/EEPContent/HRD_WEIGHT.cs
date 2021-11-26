using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_WEIGHT
    {
        public int RELATION_ID { get; set; }
        public string RELATION_NAME { get; set; }
        public int? WEIGHT { get; set; }
        public int? SEQ { get; set; }
        public string IS_SELF { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
