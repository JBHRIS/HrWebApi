using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsRecordc
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Recode { get; set; }
        public decimal? Num { get; set; }
        public bool? Mang1isOk { get; set; }
        public bool? Mang2isOk { get; set; }
        public bool? Mang3isOk { get; set; }
        public bool? Mang4isOk { get; set; }
        public bool? Mang5isOk { get; set; }
        public string Mang1Nobr { get; set; }
        public string Mang2Nobr { get; set; }
        public string Mang3Nobr { get; set; }
        public string Mang4Nobr { get; set; }
        public string Mang5Nobr { get; set; }
        public string Mang1Name { get; set; }
        public string Mang2Name { get; set; }
        public string Mang3Name { get; set; }
        public string Mang4Name { get; set; }
        public string Mang5Name { get; set; }
        public string Mang1Note { get; set; }
        public string Mang2Note { get; set; }
        public string Mang3Note { get; set; }
        public string Mang4Note { get; set; }
        public string Mang5Note { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
