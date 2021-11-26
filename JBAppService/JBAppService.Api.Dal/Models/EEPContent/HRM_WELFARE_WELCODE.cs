using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_WELFARE_WELCODE
    {
        public int WELFARE_ID { get; set; }
        public string WELFARE_CODE { get; set; }
        public string WELFARE_CNAME { get; set; }
        public string WELFARE_ENAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
