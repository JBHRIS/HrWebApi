using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UTts
    {
        public string PrgName { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public int OpCode { get; set; }
        public string Cont { get; set; }
        public string KeyTime { get; set; }
    }
}
