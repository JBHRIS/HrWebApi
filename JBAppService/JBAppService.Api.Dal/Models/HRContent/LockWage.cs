using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class LockWage
    {
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Saladr { get; set; }
        public string Meno { get; set; }
    }
}
