using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class View_HRD_SCORE_BEHAVIOR_SUM
    {
        public int FORM_ID { get; set; }
        public int FUNCTION_ID { get; set; }
        public string FUNCTION_NAME { get; set; }
        public int BEHAVIOR_ID { get; set; }
        public string BEHAVIOR_CONTENT { get; set; }
        public int? WEIGHT_SEQ { get; set; }
        public string RELATION_NAME { get; set; }
        public int? SCORE_COUNT { get; set; }
        public int? P_COUNT { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? FUNCTION_SEQ { get; set; }
        public string IS_SELF { get; set; }
    }
}
