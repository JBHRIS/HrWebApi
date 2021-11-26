using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_SALBASE_MAPPING_DETAIL_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int SALBASE_MAPPING_ID { get; set; }
        public string SALBASE_MAPPING_CODE { get; set; }
        public string MAPPING_VALUE { get; set; }
        public string MAPPING_TEXT { get; set; }
        public string MAPPING_FIELD_VALUE { get; set; }
        public int? SORT { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
    }
}
