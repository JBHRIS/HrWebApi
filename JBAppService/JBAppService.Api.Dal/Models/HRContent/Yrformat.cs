using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Yrformat
    {
        public string MFormat { get; set; }
        public string MFmtName { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal Fixrate { get; set; }
        public decimal Supplemin { get; set; }
        public decimal Supplemax { get; set; }
        public string Incometype { get; set; }
    }
}
