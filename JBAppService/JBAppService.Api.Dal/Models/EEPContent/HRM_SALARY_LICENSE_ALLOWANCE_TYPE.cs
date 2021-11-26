using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_LICENSE_ALLOWANCE_TYPE
    {
        public int LICENSE_TYPE_ID { get; set; }
        public string LICENSE_CNAME { get; set; }
        public int? CYCLE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
