using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_BASE_BASEIO
    {
        public int BASEIO_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime EFFECT_DATE { get; set; }
        public string ACTION_TYPE { get; set; }
        public int? HIRE_WAY_ID { get; set; }
        public int? ALTERATION_CAUSE_ID { get; set; }
        public DateTime? REINSTATEMENT_DATE { get; set; }
        public int? LEAVE_CAUSE_ID { get; set; }
        public string MEMO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
