using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_SALBASE_MAPPING_MASTER
    {
        public string SALBASE_MAPPING_CODE { get; set; }
        public string SALBASE_MAPPING_NAME { get; set; }
        public int? SALARY_ID { get; set; }
        public string MAPPING_FIELD { get; set; }
        public int? SALBASE_MAPPING_SORT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
