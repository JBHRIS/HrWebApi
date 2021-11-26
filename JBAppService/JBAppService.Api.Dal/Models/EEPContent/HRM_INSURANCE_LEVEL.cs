using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_INSURANCE_LEVEL
    {
        public int INSURANCE_LEVEL_ID { get; set; }
        public string INSURANCE_LEVEL_TYPE { get; set; }
        public int? INSURANCE_LEVEL { get; set; }
        public int? INSURANCE_AMT { get; set; }
        public DateTime? BEGIN_VALID_DATE { get; set; }
        public DateTime? END_VALID_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
