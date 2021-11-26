using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_CURRENCY
    {
        public int CURRENCY_ID { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string CURRENCY_CNAME { get; set; }
        public string CURRENCY_ENAME { get; set; }
        public int? CURRENCY_SEQ { get; set; }
        public string CURRENCY_STATUS { get; set; }
        public int? CURRENCY_POINT { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
    }
}
