using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_FOREIGN_WORK_TYPE
    {
        public int FOREIGN_WORK_TYPE_ID { get; set; }
        public string FOREIGN_WORK_TYPE_CODE { get; set; }
        public string FOREIGN_WORK_TYPE_CNAME { get; set; }
        public string FOREIGN_WORK_TYPE_ENAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
