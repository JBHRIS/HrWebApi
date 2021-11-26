using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CARD_COLLECT_RESULT
    {
        public int COLLECT_RESULT_ID { get; set; }
        public bool IS_UPDATE { get; set; }
        public string IMPORT_TYPE { get; set; }
        public string CARD_CONTENT { get; set; }
        public string MEMO { get; set; }
        public bool IS_OK { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
    }
}
