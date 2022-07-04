using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class CompCodeGroup
    {
        public string Comp { get; set; }
        public string Codegroup { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool DefaultCode { get; set; }
    }
}
