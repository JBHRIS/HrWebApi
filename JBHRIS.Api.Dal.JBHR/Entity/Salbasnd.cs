using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Salbasnd
    {
        public string Nobr { get; set; }
        public string YymmB { get; set; }
        public string YymmE { get; set; }
        public string SalCode { get; set; }
        public decimal Seq { get; set; }
        public DateTime ADate { get; set; }
        public bool AType { get; set; }
        public decimal APer { get; set; }
        public decimal FAmt { get; set; }
        public decimal PAmt { get; set; }
        public decimal TAmt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Memo { get; set; }
        public string Dispatch { get; set; }
        public string DeDept { get; set; }
        public string DeMan { get; set; }
        public string DeTel { get; set; }
        public string DeAdd { get; set; }
        public string LawDept { get; set; }
        public string LawMan { get; set; }
        public string LawTel { get; set; }
        public DateTime PDate { get; set; }
        public DateTime FDate { get; set; }
        public DateTime TDate { get; set; }
        public DateTime CDate { get; set; }
        public decimal PPer { get; set; }
        public string Acno { get; set; }
        public decimal MinCostLiving { get; set; }
    }
}
