using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_ATTEND_DAY_SET
    {
        public int ATTEND_DAY_SET_ID { get; set; }
        public string BEGIN_MONTH_TYPE { get; set; }
        public int? BEGIN_MONTH_DAY { get; set; }
        public string END_MONTH_TYPE { get; set; }
        public int? END_MONTH_DAY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
