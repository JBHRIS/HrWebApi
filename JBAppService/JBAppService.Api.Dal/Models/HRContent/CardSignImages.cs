using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class CardSignImages
    {
        public int AutoKey { get; set; }
        public string Guid { get; set; }
        public string Nobr { get; set; }
        public string Path { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
