using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class CardAppImages
    {
        public int AutoKey { get; set; }
        public int? CardAppDetailsId { get; set; }
        public string Nobr { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Path { get; set; }
    }
}
