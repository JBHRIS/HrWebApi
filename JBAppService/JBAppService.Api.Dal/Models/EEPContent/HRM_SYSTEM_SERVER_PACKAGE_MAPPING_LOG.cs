using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_SYSTEM_SERVER_PACKAGE_MAPPING_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string SERVER_PACKAGE_FROM { get; set; }
        public string SERVER_METHOD_FROM { get; set; }
        public string SERVER_PACKAGE_TO { get; set; }
        public string SERVER_METHOD_TO { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
