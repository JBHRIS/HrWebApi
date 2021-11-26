using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_MAPPING_MASTER
    {
        public string MAPPING_CODE { get; set; }
        public string MAPPING_TYPE { get; set; }
        public string MAPPING_TITLE { get; set; }
        public int? SEQ { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
