using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Salfunction
    {
        public int Auto { get; set; }
        public string Calctype { get; set; }
        public string Item { get; set; }
        public string Script { get; set; }
        public int Sort { get; set; }
        public bool? Calc { get; set; }
        public bool Ref { get; set; }
    }
}
