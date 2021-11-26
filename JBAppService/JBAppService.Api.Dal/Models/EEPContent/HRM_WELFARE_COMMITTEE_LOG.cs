using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_WELFARE_COMMITTEE_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string WELFARE_COMMITTEE_CODE { get; set; }
        public string WELFARE_COMMITTEE_CNAME { get; set; }
        public string WELFARE_COMMITTEE_ENAME { get; set; }
        public string TAX_ID { get; set; }
        public string TAX_CITY_OFFICE_CODE { get; set; }
        public int? COMPANY_ID { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
