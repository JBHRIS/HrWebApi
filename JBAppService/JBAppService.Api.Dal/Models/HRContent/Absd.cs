using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Absd
    {
        public int Ak { get; set; }
        public string Absadd { get; set; }
        public string Abssubtract { get; set; }
        public decimal Usehour { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
