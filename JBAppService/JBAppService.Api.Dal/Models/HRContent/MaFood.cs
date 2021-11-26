using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MaFood
    {
        public string Comp { get; set; }
        public string Rote { get; set; }
        public bool NotRote { get; set; }
        public decimal MaAmt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
