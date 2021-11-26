using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_GROUP_MASTER
    {
        public int ATTEND_GROUP_MASTER_ID { get; set; }
        public string GROUP_MASTER_CODE { get; set; }
        public string GROUP_MASTER_CNAME { get; set; }
        public string GROUP_MASTER_ENAME { get; set; }
        public int? GROUP_MASTER_SEQ { get; set; }
        public bool? IS_GROUP { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
