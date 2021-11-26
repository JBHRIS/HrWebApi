using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class MAIL_PARAMETER_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public int? MAIL_PARAMETER_ID { get; set; }
        public string PARAMETER_CODE { get; set; }
        public string PARAMERTER_NAME { get; set; }
        public string TYPE { get; set; }
        public string VALUE { get; set; }
        public string NOTE { get; set; }
        public string DISPLAY { get; set; }
        public string CREATE_MAN { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string UPDATE_MAN { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
