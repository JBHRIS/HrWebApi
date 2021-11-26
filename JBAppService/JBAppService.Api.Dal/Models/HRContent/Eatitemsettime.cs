using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Eatitemsettime
    {
        public int AutoKey { get; set; }
        public DateTime? Adate { get; set; }
        public string Workcd { get; set; }
        public bool? E1 { get; set; }
        public bool? E2 { get; set; }
        public bool? E3 { get; set; }
        public bool? E4 { get; set; }
        public bool? E5 { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
