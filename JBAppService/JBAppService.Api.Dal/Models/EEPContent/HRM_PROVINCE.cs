using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_PROVINCE
    {
        public int PROVINCE_ID { get; set; }
        public string PROVINCE_CODE { get; set; }
        public string PROVINCE_CNAME { get; set; }
        public string PROVINCE_ENAME { get; set; }
        public int? PROVINCE_SEQ { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
