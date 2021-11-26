using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_FUNCTION_BEHAVIOR
    {
        public int BEHAVIOR_ID { get; set; }
        public int? FUNCTION_ID { get; set; }
        public string BEHAVIOR_CONTENT { get; set; }
        public int? SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
