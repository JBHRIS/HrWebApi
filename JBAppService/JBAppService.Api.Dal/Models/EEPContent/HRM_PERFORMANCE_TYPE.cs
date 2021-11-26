using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_PERFORMANCE_TYPE
    {
        public int PERFORMANCE_TYPE_ID { get; set; }
        public string PERFORMANCE_TYPE_CODE { get; set; }
        public string PERFORMANCE_TYPE_CNAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
