using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class HrPortalAbs
    {
        public string Nobr { get; set; }
        public string NameC { get; set; }
        public DateTime Bdate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string HCode { get; set; }
        public string HName { get; set; }
        public string Unit { get; set; }
        public decimal TolHours { get; set; }
        public string Yymm { get; set; }
        public string Note { get; set; }
        public decimal TolDay { get; set; }
        public string YearRest { get; set; }
        public string DName { get; set; }
        public string JobName { get; set; }
    }
}
