using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_JOB_FUNCTION
    {
        public int JOB_FUNCTION_ID { get; set; }
        public string JOB_FUNCTION_CODE { get; set; }
        public string JOB_FUNCTION_NAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
