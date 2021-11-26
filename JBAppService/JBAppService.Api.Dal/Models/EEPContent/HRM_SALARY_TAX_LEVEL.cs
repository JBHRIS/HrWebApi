using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_TAX_LEVEL
    {
        public int TAX_LEVEL_ID { get; set; }
        public string YEAR { get; set; }
        public decimal UPPER_LIMIT_AMT { get; set; }
        public decimal LOWER_LIMIT_AMT { get; set; }
        public decimal? PER0 { get; set; }
        public decimal? PER1 { get; set; }
        public decimal? PER2 { get; set; }
        public decimal? PER3 { get; set; }
        public decimal? PER4 { get; set; }
        public decimal? PER5 { get; set; }
        public decimal? PER6 { get; set; }
        public decimal? PER7 { get; set; }
        public decimal? PER8 { get; set; }
        public decimal? PER9 { get; set; }
        public decimal? PER10 { get; set; }
        public decimal? PER11 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
