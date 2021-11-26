using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_PARAMETER_MAPPING_MASTER
    {
        public string PARAMETER_MAPPING_CODE { get; set; }
        public string PARAMETER_MAPPING_NAME { get; set; }
        public string IS_ENABLE { get; set; }
        public string SEQ { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
