using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ADDRESS
    {
        public int ID { get; set; }
        public int CITY_CODE { get; set; }
        public string CITY { get; set; }
        public int COUNTRY_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string ROAD { get; set; }
        public string MAIL_CODE { get; set; }
    }
}
