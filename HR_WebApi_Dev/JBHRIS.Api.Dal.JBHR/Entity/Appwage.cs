using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Appwage
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public decimal BAmt { get; set; }
        public decimal SDay { get; set; }
        public decimal RDay { get; set; }
        public decimal DDay { get; set; }
        public decimal SAmt { get; set; }
        public decimal RAmt { get; set; }
        public decimal AAmt { get; set; }
        public decimal DAmt { get; set; }
        public decimal PAmt { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Deptm { get; set; }
        public decimal BVt { get; set; }
        public decimal DVt { get; set; }
        public DateTime Indt { get; set; }
        public string NDay { get; set; }
        public decimal WDay { get; set; }
        public decimal PDay { get; set; }
        public bool Syscreate { get; set; }
        public decimal TAmt { get; set; }
    }
}
