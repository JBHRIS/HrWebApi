using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Frm22
    {
        public string Nobr { get; set; }
        public string Cardno { get; set; }
        public DateTime Bdate { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Temps { get; set; }
        public string NameC { get; set; }
        public string Dept { get; set; }
        public string Note { get; set; }
        public DateTime? Edate { get; set; }
    }
}
