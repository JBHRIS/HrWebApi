using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Rules
    {
        public string Rules1 { get; set; }
        public string RuleCode { get; set; }
        public string TimeBegin { get; set; }
        public string TimeEnd { get; set; }
        public decimal HourBegin { get; set; }
        public decimal HourEnd { get; set; }
        public decimal Fixamt { get; set; }
        public decimal Fixrate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
    }
}
