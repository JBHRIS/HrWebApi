using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class RefreshToken
    {
        public string RefreshToken1 { get; set; }
        public string Nobr { get; set; }
        public DateTime DueDate { get; set; }
        public int Lock { get; set; }
        public string Valid { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
