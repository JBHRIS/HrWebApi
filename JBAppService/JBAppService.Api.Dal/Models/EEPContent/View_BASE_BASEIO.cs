using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class View_BASE_BASEIO
    {
        public string EMPLOYEE_ID { get; set; }
        public string ACTION_TYPE { get; set; }
        public DateTime EFFECT_DATE { get; set; }
        public DateTime EFFECT_EDATE { get; set; }
    }
}
