using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Tr2docd
    {
        public string Todocode { get; set; }
        public string Tododescr { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Note { get; set; }
        public int Days { get; set; }
        public bool Used { get; set; }
    }
}
