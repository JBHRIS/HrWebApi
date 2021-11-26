using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsRecord
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string Type { get; set; }
        public string Record { get; set; }
        public DateTime? Adate { get; set; }
        public DateTime? Keydate { get; set; }
        public string Effscate { get; set; }
        public string Mangname { get; set; }
    }
}
