using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_PERFORMANCE_LEVEL
    {
        public int PERFORMANCE_LEVEL_ID { get; set; }
        public string PERFORMANCE_LEVEL_CODE { get; set; }
        public string PERFORMANCE_LEVEL_CNAME { get; set; }
        public decimal? MINIMUN_SCORE { get; set; }
        public decimal? MAXMUN_SCORE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
