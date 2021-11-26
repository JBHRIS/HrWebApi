using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrAbsUnion
    {
        public string SNobr { get; set; }
        public DateTime DDateB { get; set; }
        public DateTime DDateE { get; set; }
        public string STimeB { get; set; }
        public string STimeE { get; set; }
        public decimal IUse { get; set; }
        public string SYymm { get; set; }
        public string SHoliCode { get; set; }
        public string SHoliName { get; set; }
        public string SUint { get; set; }
        public decimal IMin { get; set; }
        public bool BInHoli { get; set; }
        public string SYearRest { get; set; }
        public decimal IMax { get; set; }
        public bool BChe { get; set; }
        public string SDcode { get; set; }
        public string SSex { get; set; }
        public bool BDiscontent { get; set; }
        public bool BDisplayform { get; set; }
        public decimal IInterval { get; set; }
        public string SName { get; set; }
    }
}
