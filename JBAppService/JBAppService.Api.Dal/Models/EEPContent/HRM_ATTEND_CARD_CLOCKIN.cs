using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_ATTEND_CARD_CLOCKIN
    {
        public int CARD_CLOCKIN_ID { get; set; }
        public int CARD_DATA_ID { get; set; }
        public string USERID { get; set; }
        public string CARD_TYPE { get; set; }
        public string IP_ADDRESS { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public DateTime? CREATE_DATE { get; set; }
    }
}
