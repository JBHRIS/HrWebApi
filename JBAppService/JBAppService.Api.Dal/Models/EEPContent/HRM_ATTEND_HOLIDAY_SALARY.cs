using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_HOLIDAY_SALARY
    {
        public int HOLIDAY_SALARY_ID { get; set; }
        public int? HOLIDAY_ID { get; set; }
        public int? SALARY_ID { get; set; }
        public decimal? RATE { get; set; }
        public int? DEDUCT_SALARY_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
