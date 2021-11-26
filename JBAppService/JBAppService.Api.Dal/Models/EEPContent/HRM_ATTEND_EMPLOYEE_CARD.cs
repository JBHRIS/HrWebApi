using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_EMPLOYEE_CARD
    {
        public int EMPLOYEE_CARD_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string CARD_NO { get; set; }
        public DateTime? EFFECT_DATE { get; set; }
        public string IS_TEMPORARY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
