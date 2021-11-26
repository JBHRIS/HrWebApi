using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_MEDIA_TAX_FORMAT_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string TAX_FORMAT_CODE { get; set; }
        public string TAX_FORMAT_CNAME { get; set; }
        public decimal? FIX_TAX_RATE { get; set; }
        public decimal? SUPPLY_MINIMUM { get; set; }
        public decimal? SUPPLY_MAXIMUM { get; set; }
        public string INCOME_TYPE { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
