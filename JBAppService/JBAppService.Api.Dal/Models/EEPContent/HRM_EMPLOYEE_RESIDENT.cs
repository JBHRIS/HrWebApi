using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_RESIDENT
    {
        public int EMPLOYEE_RESIDENT_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime? BEGIN_EFFECT_DATE { get; set; }
        public DateTime? END_EFFECT_DATE { get; set; }
        public DateTime? LEAVE_DATE { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
