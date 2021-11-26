using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Salcode
    {
        public Salcode()
        {
            RoteBonus = new HashSet<RoteBonus>();
        }

        public string SalCode1 { get; set; }
        public string SalName { get; set; }
        public string SalAttr { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string SosId { get; set; }
        public bool Wel { get; set; }
        public bool Ot { get; set; }
        public decimal MaxAmt { get; set; }
        public decimal MinAmt { get; set; }
        public string CalFreq { get; set; }
        public string CalType { get; set; }
        public decimal Hrs { get; set; }
        public string Monthtype { get; set; }
        public decimal Definedays { get; set; }
        public bool Advpay { get; set; }
        public string Acccd { get; set; }
        public bool Att { get; set; }
        public bool Daily { get; set; }
        public bool Retire { get; set; }
        public bool Forbank { get; set; }
        public bool Forcash { get; set; }
        public bool Notfreq { get; set; }
        public decimal Taxrate { get; set; }
        public bool Yearpay { get; set; }
        public bool Abspay { get; set; }
        public bool Inslab { get; set; }
        public bool Later { get; set; }
        public string SalEname { get; set; }
        public bool Oldretire { get; set; }
        public bool Salbasd1 { get; set; }
        public string SalCodeDisp { get; set; }
        public bool Sup { get; set; }
        public string SalNameVn { get; set; }
        public string SalcodeGroup { get; set; }
        public string Salbase { get; set; }
        public int? Sort { get; set; }
        public bool Notfreqseq { get; set; }
        public string Salseq { get; set; }

        public virtual ICollection<RoteBonus> RoteBonus { get; set; }
    }
}
