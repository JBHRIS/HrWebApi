using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_RATE_PATCH
    {
        public int OVERTIME_RATE_PATCH_ID { get; set; }
        public int OVERTIME_RATE_MASTER_ID { get; set; }
        public decimal? HOUR_BEGIN { get; set; }
        public decimal? HOUR_END { get; set; }
        public decimal? PATCH_HOUR { get; set; }
        public string IS_REST_HOUR { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
