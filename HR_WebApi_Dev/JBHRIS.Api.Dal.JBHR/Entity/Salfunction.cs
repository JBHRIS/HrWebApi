using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
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
