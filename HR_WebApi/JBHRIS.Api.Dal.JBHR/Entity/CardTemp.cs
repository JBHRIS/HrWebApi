using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class CardTemp
    {
        public string Code { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Ontime { get; set; }
        public string Cardno { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool NotTran { get; set; }
        public decimal Days { get; set; }
        public string Reason { get; set; }
        public bool Los { get; set; }
        public string Ipadd { get; set; }
        public string Meno { get; set; }
        public string Serno { get; set; }
    }
}
