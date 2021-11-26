using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRD_PROJECT
    {
        public int PROJECT_ID { get; set; }
        public string PROJECT_NAME { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string PROJECT_STATUS { get; set; }
        public int? COMPANY_ID { get; set; }
        public string PROJECT_EXPLAIN { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
