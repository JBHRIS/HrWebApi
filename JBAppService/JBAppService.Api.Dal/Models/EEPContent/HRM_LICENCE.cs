using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_LICENCE
    {
        public int LICENCE_ID { get; set; }
        public string LICENCE_CODE { get; set; }
        public string LICENCE_CNAME { get; set; }
        public string LICENCE_ENAME { get; set; }
        public int? LICENCE_SEQ { get; set; }
        public int? SALARY_ID { get; set; }
        public decimal? SALARY_AMT { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
