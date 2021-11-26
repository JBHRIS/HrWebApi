using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_TRAINING_COURSE_EVALUATE
    {
        public int COURSE_EVALUATE_ID { get; set; }
        public string COURSE_EVALUATE_CODE { get; set; }
        public string COURSE_EVALUATE_CNAME { get; set; }
        public string COURSE_EVALUATE_ENAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
