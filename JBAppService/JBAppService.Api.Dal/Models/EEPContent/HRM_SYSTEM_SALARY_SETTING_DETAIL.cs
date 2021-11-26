using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_SALARY_SETTING_DETAIL
    {
        public int SETTING_DETAIL_ID { get; set; }
        public int SALARY_SETTING_ID { get; set; }
        public string SALARY_PAY_TYPE { get; set; }
        public int ATTEND_BEGIN_DAY { get; set; }
        public int ATTEND_END_DAY { get; set; }
        public int SALARY_BEGIN_DAY { get; set; }
        public int SALARY_END_DAY { get; set; }
        public int PARAMETER_DAY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
