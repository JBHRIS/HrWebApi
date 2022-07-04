using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Appyear
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public decimal Fv1 { get; set; }
        public decimal Fv2 { get; set; }
        public decimal Fvt { get; set; }
        public decimal Lv1 { get; set; }
        public decimal Lv2 { get; set; }
        public decimal Lvt { get; set; }
        public decimal Tot { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal Efv1 { get; set; }
        public decimal Efv2 { get; set; }
        public decimal Efvt { get; set; }
        public decimal Elv1 { get; set; }
        public decimal Elv2 { get; set; }
        public decimal Elvt { get; set; }
        public decimal Etot { get; set; }
    }
}
