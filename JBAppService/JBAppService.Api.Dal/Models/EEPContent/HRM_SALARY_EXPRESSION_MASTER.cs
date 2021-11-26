using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_EXPRESSION_MASTER
    {
        public string EXPRESSION_CODE { get; set; }
        public string EXPRESSION_CNAME { get; set; }
        public string EXPRESSION_ENAME { get; set; }
        public string EXPRESSION_FORMULA { get; set; }
        public int? EXPRESSION_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
