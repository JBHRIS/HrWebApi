using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class BankCode
    {
        public string Code { get; set; }
        public string BankName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string CodeDisp { get; set; }
        public int Codepage { get; set; }
    }
}
