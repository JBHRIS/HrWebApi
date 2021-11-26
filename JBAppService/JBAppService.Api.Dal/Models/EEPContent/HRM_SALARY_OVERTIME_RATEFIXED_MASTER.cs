using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_OVERTIME_RATEFIXED_MASTER
    {
        public int OVERTIME_RATEFIXED_MASTER_ID { get; set; }
        public DateTime EFFECT_DATE { get; set; }
        public int OVERTIME_RATE_MASTER_ID { get; set; }
        public int? COMPANY_ID { get; set; }
        public int? ROTE_ID { get; set; }
        public int? CALENDAR_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
