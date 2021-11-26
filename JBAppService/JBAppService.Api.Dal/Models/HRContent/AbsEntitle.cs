using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class AbsEntitle
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string AbsType { get; set; }
        public string HCode { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public decimal Entitle { get; set; }
        public bool Trans { get; set; }
        public string Remark { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
