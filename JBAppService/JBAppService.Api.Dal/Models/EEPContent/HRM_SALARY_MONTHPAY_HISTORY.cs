using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SALARY_MONTHPAY_HISTORY
    {
        public int MONTHPAY_HISTORY_ID { get; set; }
        public string MONTHPAY_TYPE { get; set; }
        public string SALARY_YYMM { get; set; }
        public DateTime? EXECUTE_DATE { get; set; }
        public string EXECUTE_MAN { get; set; }
        public string DATA_CONTENT { get; set; }
    }
}
