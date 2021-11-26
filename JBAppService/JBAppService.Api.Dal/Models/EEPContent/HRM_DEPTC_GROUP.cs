using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_DEPTC_GROUP
    {
        public int DEPTC_GROUP_ID { get; set; }
        public int? DEPTC_ID { get; set; }
        public string DEPTC_CODE { get; set; }
        public string DEPTC_CNAME { get; set; }
        public int? UPPER_DEPTC_GROUP_ID { get; set; }
        public string UPPER_DEPTC_CNAME { get; set; }
        public string IS_SUM { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
