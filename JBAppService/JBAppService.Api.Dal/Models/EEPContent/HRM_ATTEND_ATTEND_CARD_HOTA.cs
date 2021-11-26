using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_ATTEND_CARD_HOTA
    {
        public int ATTEND_CARD_HOTA_ID { get; set; }
        public int ATTEND_CARD_ID { get; set; }
        public string ON_TIME_NOT_TEMP_CARD { get; set; }
        public string OFF_TIME_NOT_TEMP_CARD { get; set; }
    }
}
