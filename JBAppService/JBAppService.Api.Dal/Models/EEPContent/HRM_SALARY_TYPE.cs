using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_TYPE
    {
        public string SALARY_TYPE_CODE { get; set; }
        public string SALARY_TYPE_NAME { get; set; }
        public string SALARY_TYPE_PARA1 { get; set; }
        public decimal SALARY_TYPE_DEFINE1 { get; set; }
        public string SALARY_TYPE_PARA2 { get; set; }
        public decimal SALARY_TYPE_DEFINE2 { get; set; }
        public string SALARY_TYPE_PARA3 { get; set; }
        public decimal SALARY_TYPE_DEFINE3 { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
