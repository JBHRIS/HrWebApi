using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_REWARD
    {
        public int EMPLOYEE_REWARD_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public int? REWARD_ID { get; set; }
        public string EMPLOYEE_REWARD_LIST { get; set; }
        public string EMPLOYEE_REWARD_DESC { get; set; }
        public DateTime? EMPLOYEE_REWARD_DATE { get; set; }
        public string SALARY_YYMM { get; set; }
        public string REWARD_KIND_ID { get; set; }
        public decimal? EMPLOYEE_REWARD_CNT { get; set; }
        public decimal? EMPLOYEE_REWARD_VAL { get; set; }
        public string EMPLOYEE_REWARD_PROMOTE { get; set; }
        public string EMPLOYEE_REWARD_LAYOFF { get; set; }
        public string UPLOAD_FILE1 { get; set; }
        public string UPLOAD_FILE2 { get; set; }
        public string UPLOAD_FILE3 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
