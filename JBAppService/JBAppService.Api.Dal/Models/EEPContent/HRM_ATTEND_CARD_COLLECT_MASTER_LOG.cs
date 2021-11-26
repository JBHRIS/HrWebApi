using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CARD_COLLECT_MASTER_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string CARD_COLLECT_CODE { get; set; }
        public string GROUP_TYPE { get; set; }
        public string SPLIT_SIGNAL { get; set; }
        public bool? IS_EMPLOYEE_CODE { get; set; }
        public bool? IS_OVERWRITE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
