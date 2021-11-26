using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class HRM_PunchCardRecord
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public DateTime? BDate { get; set; }
        public string TimeB { get; set; }
        public DateTime? FullTime { get; set; }
        public string ReasonCode { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string LocationIp { get; set; }
        public string ActionType { get; set; }
        public string PunchType { get; set; }
        public string LocationGps { get; set; }
        public string ConnectType { get; set; }
        public bool IsValid { get; set; }
    }
}
