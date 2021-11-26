using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_JOB_WORK
    {
        public int JOB_WORK_ID { get; set; }
        public string JOB_WORK_CODE { get; set; }
        public string JOB_WORK_NAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
