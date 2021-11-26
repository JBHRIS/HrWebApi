using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class YearHoliday
    {
        public string Nobr { get; set; }
        public string Dept { get; set; }
        public DateTime Indt { get; set; }
        public string Years { get; set; }
        public DateTime? StopDate { get; set; }
        public DateTime? BackDate { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public int StopTimes { get; set; }
        public decimal StopYears { get; set; }
        public decimal TotalYears { get; set; }
        public decimal GetDays { get; set; }
        public string Unit { get; set; }
        public bool Syscreat { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool Ntrans { get; set; }
        public bool Ptrans { get; set; }
        public string Note { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public string Note5 { get; set; }
    }
}
