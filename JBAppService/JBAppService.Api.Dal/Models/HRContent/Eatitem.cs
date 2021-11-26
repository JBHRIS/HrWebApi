using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Eatitem
    {
        public int Autokey { get; set; }
        public string Nobr { get; set; }
        public DateTime? Adate { get; set; }
        public string Eattype { get; set; }
        public bool? Sp1 { get; set; }
        public string Sp1note { get; set; }
        public bool? Isok { get; set; }
        public string Btime { get; set; }
    }
}
