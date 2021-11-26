using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class OtratecdRote
    {
        public string OtrateCode { get; set; }
        public string Rote { get; set; }
        public decimal Ot133wtimeB { get; set; }
        public decimal Ot133wtimeE { get; set; }
        public decimal Ot133wrate { get; set; }
        public decimal Ot133wamt { get; set; }
        public decimal Ot167wtimeB { get; set; }
        public decimal Ot167wtimeE { get; set; }
        public decimal Ot167wrate { get; set; }
        public decimal Ot167wamt { get; set; }
        public decimal Ot200wtimeB { get; set; }
        public decimal Ot200wtimeE { get; set; }
        public decimal Ot200wrate { get; set; }
        public decimal Ot200wamt { get; set; }
        public string OtrateTypeh { get; set; }
        public decimal OtRestTimeB1 { get; set; }
        public decimal OtRestTimeE1 { get; set; }
        public decimal OtRestHours1 { get; set; }
        public decimal OtRestTimeB2 { get; set; }
        public decimal OtRestTimeE2 { get; set; }
        public decimal OtRestHours2 { get; set; }
        public decimal OtRestTimeB3 { get; set; }
        public decimal OtRestTimeE3 { get; set; }
        public decimal OtRestHours3 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool IsHoli { get; set; }
    }
}
