using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Cardlosd
    {
        public string Code { get; set; }
        public string Descr { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Att { get; set; }
        public int Sort { get; set; }
    }
}
