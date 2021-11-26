using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_PERFORMANCE_DATA
    {
        public int PERFORMANCE_DATA_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string PERFORMANCE_YYMM { get; set; }
        public string PERFORMANCE_TYPE_ID { get; set; }
        public string PERFORMANCE_LEVEL_ID { get; set; }
        public decimal? PERFORMANCE_SCORE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
