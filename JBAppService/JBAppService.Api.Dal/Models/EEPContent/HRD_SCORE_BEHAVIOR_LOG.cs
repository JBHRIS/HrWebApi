using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_SCORE_BEHAVIOR_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int FORM_ID { get; set; }
        public int FUNCTION_ID { get; set; }
        public int BEHAVIOR_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string EVALUATION_EMPLOYEE_ID { get; set; }
        public int? ITEM_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
