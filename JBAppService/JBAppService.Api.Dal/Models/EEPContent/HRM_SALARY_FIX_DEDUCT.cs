using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_FIX_DEDUCT
    {
        public int FIX_DEDUCT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_EFFECT_DATE { get; set; }
        public DateTime? END_EFFECT_DATE { get; set; }
        public int? SALARY_ID { get; set; }
        public decimal? AMT { get; set; }
        public string MEMO { get; set; }
        public string IS_IMPORT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
