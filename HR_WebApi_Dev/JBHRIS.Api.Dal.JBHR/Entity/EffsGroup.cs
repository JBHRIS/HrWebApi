using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsGroup
    {
        public string EffsgroupId { get; set; }
        public string Effsgroupname { get; set; }
        public string Effsgroup1 { get; set; }
        public bool? IsmangRate { get; set; }
        public int? Order { get; set; }
        public string Type { get; set; }
    }
}
