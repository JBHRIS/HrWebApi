using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Saltaxitem
    {
        public string Nobr { get; set; }
        public string Code { get; set; }
        public decimal Amt { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
    }
}
