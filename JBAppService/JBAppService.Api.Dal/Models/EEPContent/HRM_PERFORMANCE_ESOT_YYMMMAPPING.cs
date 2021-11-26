using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_PERFORMANCE_ESOT_YYMMMAPPING
    {
        public int ESOT_YYMMMAPPING_ID { get; set; }
        public string START_YYMM { get; set; }
        public string END_YYMM { get; set; }
        public string SALARY_YYMM_S { get; set; }
        public string SALARY_YYMM_E { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
