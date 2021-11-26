using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ROTE_CHANGE_DETAIL
    {
        public int ROTE_CHANGE_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public DateTime ROTE_CHANGE_DATE { get; set; }
        public string ROTE_ID { get; set; }
    }
}
