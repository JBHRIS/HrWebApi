using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class CardSignLog
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string Ssid { get; set; }
        public string Mac { get; set; }
        public string IpAddress { get; set; }
        public string AppRegistryKey { get; set; }
        public string CardTypeCode { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? CardStart { get; set; }
        public DateTime? CardProcess { get; set; }
        public DateTime? CardSend { get; set; }
        public DateTime? KeyDate { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public string Qrcode { get; set; }
    }
}
