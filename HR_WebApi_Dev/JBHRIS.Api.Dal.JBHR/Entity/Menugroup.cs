using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Menugroup
    {
        public int Ak { get; set; }
        public Guid Menugroupid { get; set; }
        public string Menugroupname { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
