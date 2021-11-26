using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_COURSE_SETS
    {
        public int COURSE_SETS_ID { get; set; }
        public int SCHOOL_ID { get; set; }
        public string COURSE_SETS_CODE { get; set; }
        public string COURSE_SETS_CNAME { get; set; }
        public string COURSE_SETS_ENAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
