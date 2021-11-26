using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class CardcdDamt
    {
        public int Auto { get; set; }
        public string Cardcd { get; set; }
        public string SalCode { get; set; }
        public string StrB { get; set; }
        public string StrE { get; set; }
        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public decimal Amt { get; set; }
        public decimal Amt2 { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        public bool Check3 { get; set; }
        public bool Check4 { get; set; }
        public bool Check5 { get; set; }
        public bool Check6 { get; set; }
        public int Sort { get; set; }
        public string Salfunction { get; set; }

        public virtual Cardcd CardcdNavigation { get; set; }
        public virtual Salcode SalCodeNavigation { get; set; }
    }
}
