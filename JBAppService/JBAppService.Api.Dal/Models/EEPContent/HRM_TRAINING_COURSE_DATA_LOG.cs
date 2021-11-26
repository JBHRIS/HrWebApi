using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_TRAINING_COURSE_DATA_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? COURSE_DATA_ID { get; set; }
        public string COURSE_CNAME { get; set; }
        public DateTime? COURSE_BEGIN_DATE { get; set; }
        public DateTime? COURSE_END_DATE { get; set; }
        public decimal? COURSE_AMT { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? TRAINING_COMPANY_ID { get; set; }
        public decimal? COURSE_HOURS { get; set; }
        public string IS_ABORAD { get; set; }
        public string IS_CLOSE { get; set; }
        public string COUNTRY { get; set; }
        public decimal? COURSE_ABSENT_HOURS { get; set; }
        public int? COURSE_ABSENT_CNT { get; set; }
        public int? COURSE_TYPE_ID { get; set; }
        public string MEMO { get; set; }
        public string LICENSE { get; set; }
        public string IS_EVALUATE { get; set; }
        public DateTime? EVALUATE_DATE { get; set; }
        public int? COURSE_EVALUATE_ID { get; set; }
        public string APPLY_NO { get; set; }
        public string HANDOUT { get; set; }
        public string RECEIPT { get; set; }
        public string IS_PLAN_IN { get; set; }
        public string IS_QUESTIONNAIRE { get; set; }
        public string TRAINING_TARGET { get; set; }
        public string ISO { get; set; }
        public string TRAINING_STYLE { get; set; }
        public string TRAINING_TEACHER { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
