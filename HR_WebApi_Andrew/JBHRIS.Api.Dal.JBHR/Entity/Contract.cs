using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Contract
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string ContractType { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public string WorkAdr { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string NotifyMessageGuid { get; set; }
        public int? AlertDay { get; set; }

        public virtual ContractType ContractTypeNavigation { get; set; }
        public virtual Base NobrNavigation { get; set; }
    }
}
