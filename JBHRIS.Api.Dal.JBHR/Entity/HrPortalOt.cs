using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class HrPortalOt
    {
        public string Nobr { get; set; }
        public string NameC { get; set; }
        public string JobName { get; set; }
        public string DName { get; set; }
        public DateTime Bdate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal TotHours { get; set; }
        public decimal OtHrs { get; set; }
        public decimal RestHrs { get; set; }
        public string Otrname { get; set; }
        public string Note { get; set; }
        public string Yymm { get; set; }
    }
}
