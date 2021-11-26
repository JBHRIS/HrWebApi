using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsView
    {
        public string Nobr { get; set; }
        public string NameC { get; set; }
        public string Efftype { get; set; }
        public decimal Effba { get; set; }
        public decimal Effbb { get; set; }
        public decimal Effvar { get; set; }
        public string Efflvl { get; set; }
        public string Yymm { get; set; }
    }
}
