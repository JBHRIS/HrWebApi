using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class CardAppDetails
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public string MAC { get; set; }
        public string IP_Address { get; set; }
        public string APP_RegistryKey { get; set; }
        public string CardTypeCode { get; set; }
        public string QRCODE { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? CardStart { get; set; }
        public DateTime? CardProcess { get; set; }
        public DateTime? CardSend { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? isEffctive { get; set; }
    }
}
