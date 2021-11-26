using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_RETIRE_RATE_TYPE
    {
        public int RETIRE_RATE_TYPE_ID { get; set; }
        public string RETIRE_RATE_TYPE_NAME { get; set; }
        public decimal? RETIRE_RATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
