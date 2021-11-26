using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_EMPLOYEE_ADDR_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? EMPLOYEE_ADDR_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string ADDR_TYPE { get; set; }
        public string POSTCODE { get; set; }
        public string ADDR { get; set; }
        public string CELL_PHONE { get; set; }
        public string TEL { get; set; }
        public string MAIL { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
