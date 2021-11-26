using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Empcd
    {
        public string Empcd1 { get; set; }
        public string Empdescr { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Nempcd { get; set; }
        public string EmpcdB { get; set; }
        public bool Formal { get; set; }
        public string Oldempcd { get; set; }
    }
}
