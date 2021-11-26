using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Otrcd
    {
        public string Otrcd1 { get; set; }
        public string Otrname { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool? Callin { get; set; }
        public bool? Display { get; set; }
        public bool? Nocalc { get; set; }
        public bool? Nofood { get; set; }
        public bool SysOt { get; set; }
        public int? Sort { get; set; }
        public string OtrcdDisp { get; set; }
    }
}
