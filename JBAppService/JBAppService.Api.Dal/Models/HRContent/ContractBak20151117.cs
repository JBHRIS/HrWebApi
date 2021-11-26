using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ContractBak20151117
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
        public string Note { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
