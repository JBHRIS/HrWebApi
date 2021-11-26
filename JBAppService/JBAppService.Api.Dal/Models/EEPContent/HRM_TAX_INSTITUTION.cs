using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_TAX_INSTITUTION
    {
        public int TAX_INSTITUTION_ID { get; set; }
        public string TAX_INSTITUTION_CODE { get; set; }
        public string TAX_INSTITUTION_CNAME { get; set; }
        public string TAX_INSTITUTION_ENAME { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
