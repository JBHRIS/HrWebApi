using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class CardAppImages
    {
        public int AutoKey { get; set; }
        public int? CardAppDetailsID { get; set; }
        public string Nobr { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Path { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
