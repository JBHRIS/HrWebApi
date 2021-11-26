using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Frm211dSalcode
    {
        public string SalCode { get; set; }
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
        public bool Basic { get; set; }
    }
}
