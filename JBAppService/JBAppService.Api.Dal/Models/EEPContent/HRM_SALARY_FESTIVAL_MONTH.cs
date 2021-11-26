using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_FESTIVAL_MONTH
    {
        public int FESTIVAL_MONTH { get; set; }
        public int SALARY_MONTH { get; set; }
        public int? YEAR_ADD { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
